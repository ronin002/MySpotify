using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;

using MySpotify.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using MySpotify.Models.Dtos;

namespace MySpotify.Services.Utils
{
    public class TokenService
    {

        public string GenerateToken(User user )// List<UserRolesDto> roles
        {


           
            UserRolesDto role = new UserRolesDto();
            role.Id = 1;
            role.Name = "UserNormal";
            role.LevelAccess = 1;


            List<UserRolesDto> roles = new List<UserRolesDto>();
            roles.Add(role);

            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            var connectionString = config.GetConnectionString("ConnectionString");
            var sectionSecurity = config.GetSection("SectionSecurity");
            var keyJwt = sectionSecurity.Value;
            //var keyJwt = config.GetValue<string>("JwtKey");

            var json = JsonSerializer.Serialize(roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(keyJwt);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, json)

                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
