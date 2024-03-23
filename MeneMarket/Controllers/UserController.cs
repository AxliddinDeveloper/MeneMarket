using MeneMarket.Models.Foundations.Users;
using MeneMarket.Models.Orchestrations.UserWithImages;
using MeneMarket.Services.Orchestrations.Users;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public ActionResult<IQueryable<User>> GelAllUsers()
        {
            IQueryable<User> allUsers =
                this.userOrchestrationService.RetrieveAllUsers();

            return Ok(allUsers);
        }

        [HttpGet("ById")]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<User>> GetUserByIdAsync(Guid id) =>
            await this.userOrchestrationService.RetrieveUserByIdAsync(id);

        [HttpPut]
        [Authorize(Roles = "Admin,User")]
        public async ValueTask<ActionResult<User>> PutUserAsync(UserWithImages userWithImages)
        {
            var user = new User
            {
                UserId = userWithImages.UserId,
                FirstName = userWithImages.FirstName,
                LastName = userWithImages.LastName,
                Email = userWithImages.Email,
                Password = userWithImages.Password,
                Balance = userWithImages.Balance,
                IsArchived = userWithImages.IsArchived,
                Role = userWithImages.Role,
            };

            return await this.userOrchestrationService.ModifyUserAsync(user, userWithImages.Image);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async ValueTask<ActionResult<User>> DeleteUserAsync(Guid id) =>
            await this.userOrchestrationService.RemoveUserByIdAsync(id);
    }
}