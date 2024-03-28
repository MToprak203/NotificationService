using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryNotificationBodyDal : InMemoryDal<NotificationBody>, INotificationBodyDal
    {
        public override IResult Update(NotificationBody entity)
        {
            NotificationBody body = _entities.Single(e => e.ID == entity.ID);

            body.Title = entity.Title;
            body.Body = entity.Body;
            body.NotificationOwner = entity.NotificationOwner;
            body.CreatedAt = entity.CreatedAt;

            return new Result(true);
        }
    }
}
