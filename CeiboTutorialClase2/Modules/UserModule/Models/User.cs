using System.Text.Json.Serialization;

namespace CeiboTutorialClase2.Modules.UserModules.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; } = "123456";

        public List<string> Roles { get; set; } = ["User"];

        public string FullName => $"{Name} {LastName}";   // public string FullName {get => $"{Name} {LastName}" ; } Sería lo mismo

    }
}
