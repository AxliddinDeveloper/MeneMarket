using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeneMarket.Brokers.Tokens
{
    public class TokenBroker
    {
        private readonly IConfiguration configuration;

        public TokenBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public UserToken GenerateJWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new UserToken
            {
                Token = tokenString,
            };
        }
    }
}
