using Core.Utilities.Results.Abstract;
using DataAccess.Concrete.DTO;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IResult AddUser(AddUserDTO userDTO);
    }
}
