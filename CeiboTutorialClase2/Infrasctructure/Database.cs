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
                LastName="Milla",
                Email="sergiomilla@ceibodigital.com" 
            },
            new User
            {
                Id= 2,
                Name="Sergio",
                LastName="Genes",
                Email="sergiogenes@ceibodigital.com",
                Roles= ["Administrator", "User"]
            },
            new User
            {
                Id= 3,
                Name="Ezequiel",
                LastName="Ibarra",
                Email="ezequielibarra@ceibodigital.com"
            },
            new User 
            {
                Id = 4,
                Name = "Tomás",
                LastName = "Apochian",
                Email="tomasapochian@ceibodigital.com"
            },
            new User
            {
                Id= 5,
                Name="David",
                LastName="Wilson",
                Email="davidwilson@ceibodigital.com"


            },
            new User
            {
                Id=6,
                Name="Malena",
                LastName="Burns",
                Email="malenaburns@ceibodigital.com"
            },
            new User
            {
                Id=7,
                Name="Lucio",
                LastName="Flores",
                Email="lucioflores@ceibodigital.com"
            },
            new User
            {
                Id=8,
                Name="Dwan",
                LastName="Flores Montenegro",
                Email="dwanfmontenegro@ceibodigital.com"

            },
            new User
            {
                Id=9,
                Name="Jaziel",
                LastName="Flores Montenegro",
                Email="jazielfmontenegro@ceibodigital.com"
            },
        ];
    }
}
