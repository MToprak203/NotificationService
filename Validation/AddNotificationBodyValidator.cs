using DataAccess.Concrete.DTO;
using FluentValidation;

namespace Validation
{
    public class AddNotificationBodyValidator : AbstractValidator<AddNotificationBodyDTO>
    {
        public AddNotificationBodyValidator()
        {
            RuleFor(nb => nb.Title).NotEmpty().WithMessage("Title can not be empty")
                .MinimumLength(3).WithMessage("Title must be longer than 3 character")
                .MaximumLength(15).WithMessage("Title must be shorter than 15 character");

            RuleFor(nb => nb.Body).NotEmpty().WithMessage("Body can not be empty");
            RuleFor(nb => nb.Owner).NotNull().WithMessage("Owner can not be null");
        }
    }
}
