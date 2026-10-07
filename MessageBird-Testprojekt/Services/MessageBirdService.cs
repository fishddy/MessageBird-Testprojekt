using MessageBird;
using MessageBird.Objects;
using MongoDB.Driver;

namespace MessageBird_Testprojekt.Services
{
    public class MessageBirdService : Abstractions.ISmsService
    {
        private readonly string _accessKey;
        public MessageBirdService(IConfiguration configuration)
        {
            _accessKey = configuration["MessageBirdSettings:AccessKey"] ?? throw new InvalidOperationException("MessageBird API Key is invalid.");
        }
        public bool SendSms(string phoneNumber, string message)
        {
            try
            {
                var client = Client.CreateDefault(_accessKey);
                phoneNumber = phoneNumber.Replace("+", "");
                var recipients = new long[] { long.Parse(phoneNumber) };
                client.SendMessage("SmsTest", message, recipients);
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"MessageBird error: {ex}");
                return false;
            }
        }
    }
}
