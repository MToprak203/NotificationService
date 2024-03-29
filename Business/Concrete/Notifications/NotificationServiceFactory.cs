using Business.Abstract;
using DataAccess.Abstract;

namespace Business.Concrete.Notifications
{
    public class NotificationServiceFactory : INotificationServiceFactory
    {
        private IEmailDal _emailDal;
        private IPhoneDal _phoneDal;
        private INotificationDal _notificationDal;

        public NotificationServiceFactory(IEmailDal emailDal, IPhoneDal phoneDal, INotificationDal notificationDal)
        {
            _emailDal = emailDal;
            _phoneDal = phoneDal;
            _notificationDal = notificationDal;
        }

        public INotificationService? Create(string notificationType)
        {
            switch (notificationType)
            {
                case "Email": return new EmailNotificationService(_emailDal, _notificationDal);
                case "Phone": return new PhoneNotificationService(_phoneDal, _notificationDal);
                case "SMS":   return new SMSNotificationService(_phoneDal, _notificationDal);
                default: return null;
            }
        }
    }
}
