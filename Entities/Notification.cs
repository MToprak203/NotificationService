namespace Entities
{
    public class Notification : IEntity
    {
        public int ID { get; set; }
        public NotificationBody NotificationBody { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}