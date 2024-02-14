using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.Tokens;

namespace MeneMarket.Brokers.Tokens
{
    public interface ITokenBroker
    {
        UserToken GenerateJWTToken(User user);
    }
}