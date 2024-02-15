using MeneMarket.Brokers.Tokens;
using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.Tokens;

namespace MeneMarket.Services.Foundations.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly ITokenBroker tokenBroker;

        public TokenService(ITokenBroker tokenBroker)
        {
            this.tokenBroker = tokenBroker;
        }

        public UserToken AddToken(User user) =>
            this.tokenBroker.GenerateJWTToken(user);
    }
}