using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        private IEmailDal _emailDal;
        private INotificationDal _notificationDal;

        object lockObject = new object();

        public EmailNotificationService(IEmailDal emailDal, INotificationDal notificationDal)
        {
            _emailDal = emailDal;
            _notificationDal = notificationDal;
        }

        public async Task<IResult> CreateNotification(NotificationBody notificationBody)
        {
            var emailsResult = _emailDal.GetAll();

            if (!emailsResult.IsSuccess) return emailsResult;

            var tasks = emailsResult.Data.Select(async email =>
            {
                Notification notification = new Notification()
                {
                    NotificationBody = notificationBody,
                    User = email.User,
                    NotificationType = "Email",
                    CreatedAt = DateTime.Now
                };

                lock (lockObject)
                {
                    _notificationDal.Add(notification);
                }
            });

            await Task.WhenAll(tasks);

            return new Result(true, "Notifications created for all emails\n");
        }

        public async Task<IResult> Notify()
        {
            var notificationsResult = _notificationDal.GetAll(n => n.NotificationType == "Email");

            if (!notificationsResult.IsSuccess) return notificationsResult;

            var copyData = new List<Notification>(notificationsResult.Data);
            var tasks = copyData.Select(async notification =>
            {
                Console.WriteLine($"User {notification.User.Name} is notified with {notification.NotificationBody.Title} Title " +
                    $"and {notification.NotificationBody.Body} Body via {notification.NotificationType}\n");

                lock (lockObject)
                {
                    _notificationDal.Delete(notification);
                }
            });

            await Task.WhenAll(tasks);

            return new Result(true, "All emails are notified");
        }
    }
}
