using MeneMarket.Models.Foundations.Users;
using MeneMarket.Services.Foundations.Users;

namespace MeneMarket.Services.Processings.Users
{
    public class UserProcessingService : IUserProcessingService
    {
        private readonly IUserService userService;

        public UserProcessingService(
            IUserService userService)
        {
            this.userService = userService;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            IQueryable<User> AllUsers = this.userService.RetrieveAllUsers();
            User UserAlreadyExsists = AllUsers.FirstOrDefault(u => u.Email == user.Email);

            if (UserAlreadyExsists == null)
                return await this.userService.AddUserAsync(user);
            else
                throw new InvalidDataException("Foydalanuvchi Allaqachon mavjud");
        }

        public IQueryable<User> RetrieveAllUsers() =>
            this.userService.RetrieveAllUsers();

        public async ValueTask<User> RetrieveUserByIdAsync(Guid id) =>
            await this.userService.RetrieveUserByIdAsync(id);

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.userService.ModifyUserAsync(user);

        public async ValueTask<User> RemoveUserByIdAsync(Guid id) =>
            await this.userService.RemoveUserAsync(id);
    }
}