namespace DataAccess.Concrete.DTO
{
    public class AddUserDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string OS { get; set; }
        public string DeviceToken { get; set; }
    }
}
