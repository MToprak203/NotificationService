using Core.Utilities.Results.Abstract;
using DataAccess.Concrete.DTO;
using Entities;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface INotificationBodyService
    {
        public IResult CreateNotification(AddNotificationBodyDTO notificationBody);
        public IDataResult<IEnumerable<NotificationBody>> GetNotificationBodies(Expression<Func<NotificationBody, bool>> filter = null);
    }
}
