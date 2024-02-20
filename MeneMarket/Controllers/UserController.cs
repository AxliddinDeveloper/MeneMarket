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

        public UserController(IUserOrchestrationService userOrchestrationService)
        {
            this.userOrchestrationService = userOrchestrationService;
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GelAllUsers()
        {
            IQueryable<User> allUsers =
                this.userOrchestrationService.RetrieveAllUsers();

            return Ok(allUsers);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userOrchestrationService.RetrieveUserByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutUserAsync(User user) =>
            await this.userOrchestrationService.ModifyUserAsync(user);

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUserAsync(Guid id) =>
            await this.userOrchestrationService.RemoveUserByIdAsync(id);
    }
}