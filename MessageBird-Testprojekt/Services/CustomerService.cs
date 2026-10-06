using MessageBird_Testprojekt.Models;
using MongoDB.Driver;

namespace MessageBird_Testprojekt.Services
{
    public class CustomerService(MongoDbService mongoDbService)
    {
        public async Task<List<Customer>> GetAllAsync()
        {
            return await mongoDbService.Customers.Find(_ => true).ToListAsync();
        }
        public async Task<Customer?> GetByIdAsync(string id)
        {
            return await mongoDbService.Customers.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
