using DataAccess.Concrete.DTO;

namespace Presentation.Seeds
{
    public class SeedUsers
    {
        static public List<AddUserDTO> Users { get; private set; } = new List<AddUserDTO>()
        {
            new AddUserDTO()
            {
                Name = "test1",
                Email = "test1@test.com",
                CountryCode = "+1",
                Phone = "0000000001",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test2",
                Email = "test2@test.com",
                CountryCode = "+70",
                Phone = "0000000002",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test3",
                Email = "test3@test.com",
                CountryCode = "+90",
                Phone = "0000000003",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test4",
                Email = "test4@test.com",
                CountryCode = "+0",
                Phone = "0000000004",
                OS = "IOS",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test5",
                Email = "test5@test.com",
                CountryCode = "+1",
                Phone = "0000000005",
                OS = "IOS",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test6",
                Email = "test6@test.com",
                CountryCode = "+154",
                Phone = "0000000006",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test7",
                Email = "test7@test.com",
                CountryCode = "+1",
                Phone = "0000000007",
                OS = "IOS",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test8",
                Email = "test8@test.com",
                CountryCode = "+1",
                Phone = "0000000008",
                OS = "IOS",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test9",
                Email = "test9@test.com",
                CountryCode = "+1",
                Phone = "0000000009",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test10",
                Email = "test10@test.com",
                CountryCode = "+85",
                Phone = "0000000010",
                OS = "IOS",
                DeviceToken = Guid.NewGuid().ToString(),
            },
            new AddUserDTO()
            {
                Name = "test11",
                Email = "test11@test.com",
                CountryCode = "+11",
                Phone = "0000000011",
                OS = "Android",
                DeviceToken = Guid.NewGuid().ToString(),
            },
        };
    }
}
