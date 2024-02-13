using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace MeneMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : RESTFulController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUser(User user) =>
            await this.userService.AddUserAsync(user);

        [HttpGet]
        public ActionResult<IQueryable<User>> GelAllUsers()
        {
            IQueryable<User> allUserss =
                this.userService.RetrieveAllUsers();

            return Ok(allUserss);
        }

        [HttpGet("ById")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userService.RetrieveUserByIdAsync(id);

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutHome(User user) =>
            await this.userService.ModifyUserAsync(user);

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeleteUser(Guid id) =>
            await this.userService.RemoveUserAsync(id);
    }
}