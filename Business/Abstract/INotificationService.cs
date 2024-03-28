using Core.Utilities.Results.Abstract;
using Entities;

namespace Business.Abstract
{
    public interface INotificationService
    {
        public Task<IResult> CreateNotification(NotificationBody notificationBody);

        public Task<IResult> Notify();
    }
}
