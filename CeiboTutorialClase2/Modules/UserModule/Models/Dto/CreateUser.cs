using System.ComponentModel.DataAnnotations;

namespace CeiboTutorialClase2.Modules.UserModules.Models.Dto
{
    public class CreateUser
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}
