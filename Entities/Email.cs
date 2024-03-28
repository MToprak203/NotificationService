namespace Entities
{
    public class Email : IEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Provider { get; set; }
        public User User { get; set; }
    }
}
