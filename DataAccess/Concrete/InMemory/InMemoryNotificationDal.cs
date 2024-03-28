using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryNotificationDal : InMemoryDal<Notification>, INotificationDal
    {
        public override IResult Update(Notification entity)
        {
            Notification notification = _entities.Single(e => e.ID == entity.ID);

            notification.NotificationBody = entity.NotificationBody;
            notification.User = entity.User;

            return new Result(true);
        }
    }
}
