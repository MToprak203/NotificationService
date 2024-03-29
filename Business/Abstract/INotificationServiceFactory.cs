using DataAccess.Abstract;

namespace Business.Abstract
{
    public interface INotificationServiceFactory
    {
        public INotificationService? Create(string notificationType);
    }
}
