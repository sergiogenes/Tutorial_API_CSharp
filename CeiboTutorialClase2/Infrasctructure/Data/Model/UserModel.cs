using MongoDB.Bson.Serialization.Attributes;

namespace CeiboTutorialClase2.Infrasctructure.Data.Model
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public string? Password { get; set; } = "123456";

        public List<string> Roles { get; set; } = ["User"];
    }
}
