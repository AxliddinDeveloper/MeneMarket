using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.DonatedUsers;

namespace MeneMarket.Models.Foundations.DonationBoxes
{
    public class DonationBox
    {
        public Guid DonationBoxId { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public virtual ICollection<DonatedUser> Users { get; set; }
    }
}