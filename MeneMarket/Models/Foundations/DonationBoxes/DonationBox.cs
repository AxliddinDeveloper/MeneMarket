using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Foundations.DonationBoxes
{
    public class DonationBox
    {
        public Guid DonationBoxId { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<User> DonatedUsers { get; set; }
    }
}