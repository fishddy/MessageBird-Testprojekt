namespace MessageBird_Testprojekt.Abstractions
{
    public interface ISmsService
    {
        bool SendSms(string phoneNumber, string message);
    }
}
