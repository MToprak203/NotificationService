using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryPhoneDal : InMemoryDal<Phone>, IPhoneDal
    {
        public override IResult Update(Phone entity)
        {
            Phone phone = _entities.Single(e => e.ID == entity.ID);

            phone.Number = entity.Number;
            phone.User = entity.User;
            phone.DeviceToken = entity.DeviceToken;
            phone.OS = entity.OS;
            phone.CountryCode = entity.CountryCode;

            return new Result(true);
        }
    }
}
