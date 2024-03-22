using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace MeneMarket.Brokers.Tokens
{
    public class TokenBroker : ITokenBroker
    {
        public UserToken GenerateJWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6AD2EF4v89d4v9dse98df784DE-Ada98f4as894B2C-48sd4v98s7v98sd78dg8d49g"));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(10),
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