using Entities;

namespace DataAccess.Concrete.DTO
{
    public class AddNotificationBodyDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public User Owner { get; set; }
    }
}
