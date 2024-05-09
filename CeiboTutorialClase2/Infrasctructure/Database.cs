using CeiboTutorialClase2.Models;
using System.Xml.Linq;

namespace CeiboTutorialClase2.Infrasctructure
{
    public static class Database
    {

        public static List<User> Users { get; set; } =
        [
            new User
            {
                Id= 1,
                Name="Sergio",
                LastName="Milla"
            },
            new User
            {
                Id= 2,
                Name="Sergio",
                LastName="Genes"
            },
            new User
            {
                Id= 3,
                Name="Ezequiel",
                LastName="Ibarra"
            },
            new User 
            {
                Id = 4,
                Name = "Tomás",
                LastName = "Apochian"
            },
            new User
            {
                Id= 5,
                Name="David",
                LastName="Wilson"

            },
            new User
            {
                Id=6,
                Name="Malena",
                LastName="Burns"
            },
            new User
            {
                Id=7,
                Name="Lucio",
                LastName="Flores"
            },
            new User
            {
                Id=8,
                Name="Dwan",
                LastName="Flores Montenegro"
            },
            new User
            {
                Id=9,
                Name="Jaziel",
                LastName="Flores Montenegro"
            },
        ];
    }
}
