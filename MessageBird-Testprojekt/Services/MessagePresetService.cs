using MessageBird_Testprojekt.Models;
using MongoDB.Driver;

namespace MessageBird_Testprojekt.Services
{
    public class MessagePresetService(MongoDbService mongoDbService)
    {
        public async Task<IEnumerable<MessagePreset>> GetAll()
        {
            return await mongoDbService.MessagePresets.Find(_ => true).ToListAsync();
        }
        public async Task<MessagePreset?> GetByIdAsync(string id)
        {
            return await mongoDbService.MessagePresets.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
