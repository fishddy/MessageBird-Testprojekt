using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageBird_Testprojekt.Models
{
    public class MessagePreset
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;
        [BsonElement("text")]
        public string Text { get; set; } = string.Empty;
    }
}
