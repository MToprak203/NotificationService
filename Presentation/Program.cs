using Business.Abstract;
using Business.Concrete;
using Business.Concrete.Notifications;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Presentation.Seeds;

IPhoneDal phoneDal = new InMemoryPhoneDal();
IEmailDal emailDal = new InMemoryEmailDal();
IUserDal  userDal  = new InMemoryUserDal();
INotificationDal notificationDal = new InMemoryNotificationDal();
INotificationBodyDal notificationBodyDal = new InMemoryNotificationBodyDal();

IUserService userService = new UserService(userDal, phoneDal, emailDal);
INotificationServiceFactory notificationServiceFactory = new NotificationServiceFactory(emailDal, phoneDal, notificationDal);
INotificationBodyService notificationBodyService = new NotificationBodyService(notificationBodyDal);

foreach (var seedUser in SeedUsers.Users)
{
    userService.AddUser(seedUser);
}

foreach (var seedNB in SeedNotificationBodies.notificationBodies)
{
    notificationBodyService.CreateNotificationBody(seedNB);
}


async void EmailNotification()
{
    INotificationService? emailNotificationService = notificationServiceFactory.Create("Email");

    var dataResult = notificationBodyService.GetNotificationBodies();

    Console.WriteLine(dataResult.Message);
    if (!dataResult.IsSuccess) return;

    var randomNB = GetRandomElement(dataResult.Data);
    var result = await emailNotificationService.CreateNotification(randomNB);

    Console.WriteLine(result.Message);
    if (!result.IsSuccess) return;

    result = await emailNotificationService.Notify();

    Console.WriteLine(result.Message);
}

async void PhoneNotification()
{
    INotificationService? phoneNotificationService = notificationServiceFactory.Create("Phone");

    var dataResult = notificationBodyService.GetNotificationBodies();

    Console.WriteLine(dataResult.Message);
    if (!dataResult.IsSuccess) return;

    var randomNB = GetRandomElement(dataResult.Data);
    var result = await phoneNotificationService.CreateNotification(randomNB);

    Console.WriteLine(result.Message);
    if (!result.IsSuccess) return;

    result = await phoneNotificationService.Notify();

    Console.WriteLine(result.Message);
}

async void SMSNotification()
{
    INotificationService? smsNotificationService = notificationServiceFactory.Create("SMS");

    var dataResult = notificationBodyService.GetNotificationBodies();

    Console.WriteLine(dataResult.Message);
    if (!dataResult.IsSuccess) return;

    var randomNB = GetRandomElement(dataResult.Data);
    var result = await smsNotificationService.CreateNotification(randomNB);

    Console.WriteLine(result.Message);
    if (!result.IsSuccess) return;

    result = await smsNotificationService.Notify();

    Console.WriteLine(result.Message);
}

T GetRandomElement<T>(IEnumerable<T> collection)
{
    Random rand = new Random();
    int index = rand.Next(collection.Count());
    return collection.ElementAt(index);
}

EmailNotification();
PhoneNotification();
SMSNotification();