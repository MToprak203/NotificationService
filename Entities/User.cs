namespace Entities
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
    }
}
