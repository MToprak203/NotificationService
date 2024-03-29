using DataAccess.Concrete.DTO;
using FluentValidation;

namespace Validation
{
    public class AddUserValidator : AbstractValidator<AddUserDTO>
    {
        public AddUserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Email is not valid");
            RuleFor(user => user.CountryCode).NotEmpty().Must(StartsWithPlus).WithMessage("Country code must start with '+'");
            RuleFor(user => user.Phone).NotEmpty().Must(BeValidPhoneNumber).WithMessage("Phone must contain only digits and have a valid length");
        }

        private bool StartsWithPlus(string countryCode)
        {
            return countryCode.StartsWith("+");
        }

        private bool BeValidPhoneNumber(string phone)
        {
            if (!phone.All(char.IsDigit))
                return false;

            const int expectedLength = 10;

            return phone.Length == expectedLength;
        }
    }
}
