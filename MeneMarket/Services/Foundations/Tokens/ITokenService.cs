using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.Tokens;

namespace MeneMarket.Services.Foundations.Tokens
{
    public interface ITokenService
    {
        public UserToken AddToken(User user);
    }
}