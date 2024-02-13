using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.Users
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsArchived {  get; set; }
        public Role Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
