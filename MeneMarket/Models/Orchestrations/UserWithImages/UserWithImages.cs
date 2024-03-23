using System.ComponentModel.DataAnnotations;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Orchestrations.UserWithImages
{
    public class UserWithImages
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public bool IsArchived { get; set; }
        public Role Role { get; set; }

        public IFormFile Image {  get; set; }
    }
}
