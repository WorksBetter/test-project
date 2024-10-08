using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; } = string.Empty;  // Initialize with an empty string

   [BsonElement("Name")]
   public string Name { get; set; } = string.Empty; // Initialize with an empty string

   [BsonElement("Email")]
   public string Email { get; set; } = string.Empty; // Initialize with an empty string


   // GDPR related fields
   [BsonElement("ConsentGiven")]
   public bool ConsentGiven { get; set; }

   [BsonElement("DataAccessedAt")]
   public DateTime? DataAccessedAt { get; set; }

   [BsonElement("DeletedAt")]
   public DateTime? DeletedAt { get; set; }
}