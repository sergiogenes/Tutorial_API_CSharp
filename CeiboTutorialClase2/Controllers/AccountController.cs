using CeiboTutorialClase2.Infrasctructure;
using CeiboTutorialClase2.Modules.TokenModule.Services;
using CeiboTutorialClase2.Modules.UserModules.Models.Dto;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace CeiboTutorialClase2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenService tokenService;
        public AccountController(TokenService tokenService) 
        {
            this.tokenService = tokenService;
        }


        [HttpPost]
        public IResult Login([FromBody] AccountLogin login)
        {
            var user = Database.Users.FirstOrDefault(u => u.Email == login.Email);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name ),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ),
            };

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role , role)));

            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(claims ,
                    BearerTokenDefaults.AuthenticationScheme
                    )
                );
            return Results.SignIn( claimsPrincipal );
        }

        //[HttpGet]
        //[Authorize]

        //public IResult Logout()
        //{
        //    var user = User;

        //    Response.Cookies.Delete(".AspNetCore.Session");
        //    Response.Cookies.Delete(".AspNetCore.Identity.SecurityToken");

        //    return Results.SignOut();
        //}

        [HttpPost("loginJWT")]
        public IActionResult Loginjwt ([FromBody] AccountLogin login)
        {
            var user = Database.Users.FirstOrDefault( u => u.Email == login.Email);

            var token = tokenService.MakeToken(user!);
            
            return Ok(token);
        }
    }
}
