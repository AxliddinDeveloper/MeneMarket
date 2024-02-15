using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.LoginUsers;
using MeneMarket.Models.Orchestrations.Tokens;
using MeneMarket.Services.Orchestrations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccauntController : RESTFulController
    {
        private readonly IUserSecurityOrchestrationService userSecurityOrchestrationService;

        public AccauntController(IUserSecurityOrchestrationService userSecurityOrchestrationService) =>
            this.userSecurityOrchestrationService = userSecurityOrchestrationService;

        [HttpPost("Register")]
        public async ValueTask<ActionResult<User>> Register(User user) =>
             await this.userSecurityOrchestrationService.AddUserAsync(user);

        [HttpPost("Login")]
        public ActionResult<UserToken> Login(LoginUser loginUser) =>
            this.userSecurityOrchestrationService.LoginUser(loginUser);
    }
}