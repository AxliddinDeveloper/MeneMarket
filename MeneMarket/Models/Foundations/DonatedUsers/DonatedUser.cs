using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.DonationBoxes;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Foundations.DonatedUsers
{
    public class DonatedUser
    {
        public Guid Id { get; set; }
        public decimal DonationPrice { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public Guid DonationBoxId { get; set; }
        [JsonIgnore]
        public virtual DonationBox DonationBox { get; set; }
    }
}