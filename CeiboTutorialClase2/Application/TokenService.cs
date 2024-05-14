using CeiboTutorialClase2.Domain.Entities.TokenModels;
using CeiboTutorialClase2.Domain.Entities.UserModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CeiboTutorialClase2.Application
{

    public class TokenService(IConfiguration configuration)
    {
        private readonly IConfiguration configuration = configuration;

        public Token MakeToken(User user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email.ToString(), user.Email),
                new(ClaimTypes.NameIdentifier.ToString(), user.Id.ToString()),
                new(ClaimTypes.Name, user.Name),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
            };

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtConfig:ExpireDays"]));

            var _token = new JwtSecurityToken(
                configuration["JwtConfig:Issuer"],
                configuration["JwtConfig:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(_token);

            return new Token { AccessToken = token, ExpireIn = expires };
        }
    }
}
