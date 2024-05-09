using CeiboTutorialClase2.Dto;

namespace CeiboTutorialClase2.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public string? Password { get; set; } = "Este es el password superr secreto del usuario"; 

        public string FullName => $"{Name} {LastName}";   // public string FullName {get => $"{Name} {LastName}" ; } Sería lo mismo

        public ViewUser view => new ViewUser
        {
            Id = this.Id,
            Name = this.Name,
            LastName = this.LastName,

        };
    }
}
