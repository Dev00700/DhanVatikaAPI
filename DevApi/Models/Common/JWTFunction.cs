using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevApi.Models.Common
{
   
    public   class JWTFunction
    {
        private  readonly IConfiguration configuration;
        public   JWTFunction(IConfiguration _configuration)
        {
                this.configuration = _configuration;
        }
        public   string GenerateJwtToken(long UserId)
        {
            // string value = System.Configuration.ConfigurationManager.AppSettings["Jwt:key"];
            var keee = configuration["Jwt:Key"];
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var sessionToken = Guid.NewGuid(); // <--- This will be saved in DB
            var claims = new[]
            {
            new Claim("UserId", UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, sessionToken.ToString()),
            new Claim(ClaimTypes.Name, UserId.ToString())
            
        };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(200),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
