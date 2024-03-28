using DataAccess.Concrete.DTO;

namespace Business.Abstract
{
    public interface IUserService
    {
        public void AddUser(AddUserDTO userDTO);
    }
}
