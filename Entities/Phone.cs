namespace Entities
{
    public class Phone : IEntity
    {
        public int ID { get; set; }
        public string DeviceToken { get; set; }
        public string OS { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public User User { get; set; }
    }
}
