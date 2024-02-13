using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Orchestrations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserOrchestrationService userOrchestrationService;

        public UserController(
            IUserOrchestrationService userOrchestrationService) =>
                this.userOrchestrationService = userOrchestrationService;

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUser(User user) =>
            await this.userOrchestrationService.AddUserAsync(user);

        [HttpGet]
        public ActionResult<IQueryable<User>> GelAllUsers()
        {
            IQueryable<User> allUserss =
                this.userOrchestrationService.RetrieveAllUsers();

            return Ok(allUserss);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userOrchestrationService.RetrieveUserByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutHome(User user) =>
            await this.userOrchestrationService.ModifyUserAsync(user);

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUser(Guid id) =>
            await this.userOrchestrationService.RemoveUserAsync(id);
    }
}