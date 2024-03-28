using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryUserDal : InMemoryDal<User>, IUserDal
    {
        public override IResult Update(User entity)
        {
            User user = _entities.Single(e => e.ID == entity.ID);

            user.Phone = entity.Phone;
            user.Email = entity.Email;
            user.Name = entity.Name;

            return new Result(true);
        }
    }
}
