using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryEmailDal : InMemoryDal<Email>, IEmailDal
    {
        public override IResult Update(Email entity)
        {
            Email email = _entities.Single(e => e.ID == entity.ID);
            
            email.Username = entity.Username;
            email.User = entity.User;
            email.Provider = entity.Provider;

            return new Result(true);
        }
    }
}
