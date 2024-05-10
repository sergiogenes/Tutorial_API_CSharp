using CeiboTutorialClase2.Dto;
using CeiboTutorialClase2.Infrasctructure;
using CeiboTutorialClase2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeiboTutorialClase2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]                        //[Authorize(Policy = "Administrator Policy")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int limit = 3 )
        {
            //var qPage = Request.Query["page"].ToString();
            //var qLimit = Request.Query["limit"].ToString();

            //var page = Convert.ToInt32(qPage);
            //var limit = Convert.ToInt32(qLimit);
            
            var users = Database.Users.Skip((page - 1) * limit).Take(limit);

            //var viewUsers = users.Select(u => u.view );

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var user = Database.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUser user)
        {
            var newUser = new User
            {
                Name = user.Name,
                LastName = user.LastName,
            };
            
            newUser.Id = Database.Users.Last().Id + 1;

            Database.Users.Add(newUser);

            return Created($"api/users/{newUser.Id}", newUser);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] CreateUser user)
        {
            var dbUser = Database.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                return NotFound("Usuario no encontrado");
            }

            dbUser.Name = user.Name;
            dbUser.LastName = user.LastName;

            return Ok(dbUser);
        }

        [HttpPatch("{id}")] 
        
        public IActionResult PartialUpdate(int id, [FromBody] PartialUser user)
        {
            var dbUser = Database.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                return NotFound("Usuario no encontrado");
            }

            dbUser.Name = user.Name ?? dbUser.Name;
            dbUser.LastName = user.LastName ?? dbUser.LastName;

            return Ok(dbUser);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var dbUser = Database.Users.FirstOrDefault(u => u.Id ==id);

            if(dbUser == null)
            {
                return NotFound("Usuario no encontrado");
            }

            Database.Users.Remove(dbUser);

            return Ok(dbUser); 
        }
    }
}
