using MessageBird_Testprojekt.Models;
using MongoDB.Driver;

namespace MessageBird_Testprojekt.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDbSettings:ConnectionString"];
            var databaseName = configuration["MongoDbSettings:DatabaseName"];

            var client = new MongoClient(connectionString);

            _database = client.GetDatabase(databaseName);

        }
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("customers");
        public IMongoCollection<MessagePreset> MessagePresets => _database.GetCollection<MessagePreset>("messagePresets");

    }
}
