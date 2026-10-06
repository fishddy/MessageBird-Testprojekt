using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageBird_Testprojekt.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("creditNumber")]
        public string CreditNumber { get; set; } = string.Empty;
        [BsonElement("amount")]
        public decimal Amount { get; set; }
        [BsonElement("dueDate")]
        public string DueDate { get; set; } = string.Empty;
    }
}
