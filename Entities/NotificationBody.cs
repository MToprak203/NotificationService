namespace Entities
{
    public class NotificationBody : IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User NotificationOwner { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
