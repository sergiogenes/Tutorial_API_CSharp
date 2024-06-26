﻿using System.ComponentModel.DataAnnotations;

namespace CeiboTutorialClase2.Application.UserCase.Dto
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
