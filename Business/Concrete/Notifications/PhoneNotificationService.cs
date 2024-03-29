using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class PhoneNotificationService : INotificationService
    {
        private IPhoneDal _phoneDal;
        private INotificationDal _notificationDal;
        object lockObject = new object();

        public PhoneNotificationService(IPhoneDal phoneDal, INotificationDal notificationDal)
        {
            _phoneDal = phoneDal;
            _notificationDal = notificationDal;
        }

        public async Task<IResult> CreateNotification(NotificationBody notificationBody)
        {
            var phonesResult = _phoneDal.GetAll();

            if (!phonesResult.IsSuccess) return phonesResult;

            var tasks = phonesResult.Data.Select(async phone =>
            {
                Notification notification = new Notification()
                {
                    NotificationBody = notificationBody,
                    User = phone.User,
                    NotificationType = phone.OS,
                    CreatedAt = DateTime.Now
                };

                lock (lockObject)
                {
                    _notificationDal.Add(notification);
                }
            });

            await Task.WhenAll(tasks);

            return new Result(true, "Notifications created for all phones");
        }

        public async Task<IResult> Notify()
        {
            var notificationsResult = _notificationDal.GetAll(n => n.NotificationType == "Android" || n.NotificationType == "IOS");

            if (!notificationsResult.IsSuccess) return notificationsResult;

            var copyData = new List<Notification>(notificationsResult.Data);
            var tasks = copyData.Select(async notification =>
            {
                if (notification.NotificationType == "Android")
                    await NotifyAndroid(notification);
                else if (notification.NotificationType == "IOS")
                    await NotifyIOS(notification);

                lock (lockObject)
                {
                    _notificationDal.Delete(notification);
                }
            });

            await Task.WhenAll(tasks);

            return new Result(true, "All phones are notified");
        }

        private Task NotifyIOS(Notification notification)
        {
            string phoneNumber = notification.User.Phone.CountryCode + notification.User.Phone.Number;
            Console.WriteLine($"User {notification.User.Name} is notified with {notification.NotificationBody.Title} Title " +
                    $"and {notification.NotificationBody.Body} Body via {phoneNumber} numbered {notification.NotificationType} phone\n\n");

            return Task.CompletedTask;
        }

        private Task NotifyAndroid(Notification notification)
        {
            string phoneNumber = notification.User.Phone.CountryCode + notification.User.Phone.Number;
            Console.WriteLine($"User {notification.User.Name} is notified with {notification.NotificationBody.Title} Title " +
                    $"and {notification.NotificationBody.Body} Body via {phoneNumber} numbered {notification.NotificationType} phone\n\n");

            return Task.CompletedTask;
        }
    }
}
