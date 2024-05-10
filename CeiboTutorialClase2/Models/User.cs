using CeiboTutorialClase2.Dto;
using System.Text.Json.Serialization;

namespace CeiboTutorialClase2.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; } = "123456";

        public string Role { get; set; } = "User";

        public string FullName => $"{Name} {LastName}";   // public string FullName {get => $"{Name} {LastName}" ; } Sería lo mismo

    }
}
