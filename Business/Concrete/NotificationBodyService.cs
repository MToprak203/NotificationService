using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.DTO;
using Entities;
using FluentValidation;
using System.Linq.Expressions;
using Validation;

namespace Business.Concrete
{
    public class NotificationBodyService
    {
        private INotificationBodyDal _notificationBodyDal;

        public NotificationBodyService(INotificationBodyDal notificationBodyDal)
        {
            _notificationBodyDal = notificationBodyDal;
        }
        public IResult CreateNotification(AddNotificationBodyDTO notificationBody)
        {
            IValidator<AddNotificationBodyDTO> validator = new AddNotificationBodyValidator();

            var validationResult = validator.Validate(notificationBody);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors;
                string message = "";

                foreach (var error in errors)
                    message += $"While Creating Notification Body:\nProperty: {error.PropertyName}, Error: {error.ErrorMessage}\n\n";

                return new Result(false, message);
            }

            if (_notificationBodyDal.Get(nb => nb.Title == notificationBody.Title && nb.NotificationOwner == notificationBody.Owner) != null)
            {
                return new Result(false, "There is same titled notification");
            }

            NotificationBody nb = new NotificationBody();
            nb.Title = notificationBody.Title;
            nb.Body = notificationBody.Body;
            nb.NotificationOwner = notificationBody.Owner;
            nb.CreatedAt = DateTime.Now;

            _notificationBodyDal.Add(nb);

            return new Result(true);
        }

        public IDataResult<IEnumerable<NotificationBody>> GetNotificationBodies(Expression<Func<NotificationBody, bool>> filter = null)
        {
            return _notificationBodyDal.GetAll(filter);
        }

    }
}
