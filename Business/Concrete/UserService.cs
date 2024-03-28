using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.DTO;
using Entities;
using FluentValidation;
using Validation;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private IPhoneDal _phoneDal;
        private IEmailDal _emailDal;

        public UserService(IUserDal userDal, IPhoneDal phoneDal, IEmailDal emailDal)
        {
            _userDal = userDal;
            _phoneDal = phoneDal;
            _emailDal = emailDal;
        }

        public IResult AddUser(AddUserDTO userDTO)
        {
            IValidator<AddUserDTO> validator = new AddUserValidator();

            var validationResult = validator.Validate(userDTO);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors;
                string message = "";

                foreach (var error in errors)
                    message += $"While Adding User:\nProperty: {error.PropertyName}, Error: {error.ErrorMessage}\n\n";
                
                return new Result(false, message);
            }


            User newUser = new User();
            newUser.Name = userDTO.Name;

            var newPhone = CreatePhone(userDTO);
            newPhone.User = newUser;
            newUser.Phone = newPhone;

            var newEmail = CreateEmail(userDTO);
            newEmail.User = newUser;
            newUser.Email = newEmail;

            // If databased is used, transaction should be used.

            if (_emailDal.Get(e => e.Username == newEmail.Username && e.Provider == newEmail.Provider) != null)
                return new Result(false, "Email is using");
            

            if (_phoneDal.Get(p => p.CountryCode == newPhone.CountryCode && p.Number == newPhone.Number) != null)
                return new Result(false, "Phone is using");
            

            var emailResult = _emailDal.Add(newEmail);
            var phoneResult = _phoneDal.Add(newPhone);
            var userResult = _userDal.Add(newUser);

            return new Result(true, "User added");
        }

        private Phone CreatePhone(AddUserDTO userDTO) 
        { 
            var phone = new Phone();
            phone.Number = userDTO.Phone;
            phone.CountryCode = userDTO.CountryCode;
            phone.DeviceToken = userDTO.DeviceToken;
            return phone;
        }

        private Email CreateEmail(AddUserDTO userDTO)
        {
            var email = new Email();
            string[] parts = userDTO.Email.Split('@');
            email.Username = parts[0];
            email.Provider = parts[1];
            return email;
        }
    }
}
