using CeiboTutorialClase2.Infrasctructure;
using CeiboTutorialClase2.Modules.UserModule.Servicies;
using CeiboTutorialClase2.Modules.UserModules.Models;
using CeiboTutorialClase2.Modules.UserModules.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeiboTutorialClase2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]                        //[Authorize(Policy = "Administrator Policy")]
        
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 3 )
        {
            
            var users = await userService.GetAllAsync(page, limit);


            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Get(int id) 
        {
            var user = await userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUser user)
        {
            var newUser = await userService.CreateAsync(user);
           
            return Created($"api/users/{newUser.Id}", newUser);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] PartialUser user)
        {
            var dbUser = await userService.UpdateAsync( id , user);

            if (dbUser == null)
            {
                return NotFound("User not found");
            }

            return Ok(dbUser);
        }

        [HttpPatch("{id}")] 
        
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] PartialUser user)
        {
            var dbUser = await userService.UpdateAsync(id, user);

            if (dbUser == null)
            {
                return NotFound("User not found");
            }

            return Ok(dbUser);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var dbUser = await userService.DeleteAsync(id);

            if(dbUser == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(dbUser); 
        }
    }
}
