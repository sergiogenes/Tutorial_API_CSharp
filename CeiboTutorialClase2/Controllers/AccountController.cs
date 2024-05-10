using CeiboTutorialClase2.Dto;
using CeiboTutorialClase2.Infrasctructure;
using Microsoft.AspNetCore.Authentication.BearerToken;
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
        [HttpPost]
        public IResult Login([FromBody] AccountLogin login)
        {
            var user = Database.Users.FirstOrDefault(u => u.Email == login.Email);

            var claimsPrincipal = new ClaimsPrincipal(
                new ClaimsIdentity(
                    [
                    new Claim(ClaimTypes.Name, user.Name ),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ),
                    new Claim(ClaimTypes.Role, user.Role),
                    ],
                    BearerTokenDefaults.AuthenticationScheme
                    )
                );
            return Results.SignIn( claimsPrincipal );
        }
    }
}
