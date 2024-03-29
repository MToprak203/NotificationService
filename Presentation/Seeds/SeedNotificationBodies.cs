using DataAccess.Concrete.DTO;
using Entities;

namespace Presentation.Seeds
{
    public class SeedNotificationBodies
    {
        static public List<AddNotificationBodyDTO> notificationBodies = new List<AddNotificationBodyDTO>()
        {
            new AddNotificationBodyDTO
            {
                Title = "Hello1",
                Body = "Hello1",
                Owner = new User()
            },
            new AddNotificationBodyDTO
            {
                Title = "Hello2",
                Body = "Hello2",
                Owner = new User()
            },
             new AddNotificationBodyDTO
            {
                Title = "Hello3",
                Body = "Hello3",
                Owner = new User()
            },
              new AddNotificationBodyDTO
            {
                Title = "Hello4",
                Body = "Hello4",
                Owner = new User()
            },
               new AddNotificationBodyDTO
            {
                Title = "Hello5",
                Body = "Hello5",
                Owner = new User()
            },
                new AddNotificationBodyDTO
            {
                Title = "Hello6",
                Body = "Hello6",
                Owner = new User()
            },
        };
    }
}
