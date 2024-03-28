using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
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
            var result = _emailDal.GetAll();

            if (!result.IsSuccess) return result;

            var tasks = result.Data.Select(async email =>
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

            return new Result(true, "Notification for all emails created");
        }

        public Task<IResult> Notify()
        {
            throw new NotImplementedException();
        }
    }
}
