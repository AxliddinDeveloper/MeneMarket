using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Orchestrations.UserWithImages
{
    public class UserWithImages
    {
        public User User { get; set; }
        public IFormFile Image {  get; set; }
    }
}
