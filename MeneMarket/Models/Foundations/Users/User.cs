using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.BalanceHistorys;
using MeneMarket.Models.Foundations.DonatedUsers;
using MeneMarket.Models.Foundations.OfferLinks;

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
        public decimal Balance { get; set; }
        public bool IsArchived { get; set; }
        public Role Role { get; set; }
        public string Image { get; set; }   
        public virtual ICollection<OfferLink> OfferLinks { get; set; }
        public virtual ICollection<BalanceHistory> BalanceHistorys { get; set; }
        [JsonIgnore]
        public virtual ICollection<DonatedUser> DonatedUsers { get; set; }
    }
}