using Business.Abstract;
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

        public void AddUser(AddUserDTO userDTO)
        {
            IValidator<AddUserDTO> validator = new AddUserValidator();

            var validationResult = validator.Validate(userDTO);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors;

                foreach (var error in errors)
                {
                    Console.WriteLine($"While Adding User:\nProperty: {error.PropertyName}, Error: {error.ErrorMessage}");
                }
                return;
            }


            User newUser = new User();
            newUser.Name = userDTO.Name;

            var newPhone = CreatePhone(userDTO);
            newPhone.User = newUser;
            newUser.Phone = newPhone;

            var newEmail = CreateEmail(userDTO);
            newEmail.User = newUser;
            newUser.Email = newEmail;

            // I need to add transaction here
            var emailResult = _emailDal.Add(newEmail);
            var phoneResult = _phoneDal.Add(newPhone);
            var userResult = _userDal.Add(newUser);
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
