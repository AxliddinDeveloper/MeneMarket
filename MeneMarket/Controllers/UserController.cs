using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Processings.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserProcessingService userProcessingService;

        public UserController(IUserProcessingService userProcessingService) =>
            this.userProcessingService = userProcessingService;

        [HttpGet]
        public ActionResult<IQueryable<User>> GelAllUsers()
        {
            IQueryable<User> allUserss =
                this.userProcessingService.RetrieveAllUsers();

            return Ok(allUserss);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userProcessingService.RetrieveUserByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutHome(User user) =>
            await this.userProcessingService.ModifyUserAsync(user);

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUser(Guid id) =>
            await this.userProcessingService.RemoveUserByIdAsync(id);
    }
}