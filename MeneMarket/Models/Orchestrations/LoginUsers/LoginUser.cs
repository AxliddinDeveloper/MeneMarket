using System.ComponentModel.DataAnnotations;

namespace MeneMarket.Models.Orchestrations.LoginUsers
{
    public class LoginUser
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}