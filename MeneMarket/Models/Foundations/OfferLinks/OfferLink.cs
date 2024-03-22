using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Clients;
using MeneMarket.Models.Foundations.Products;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Foundations.OfferLinks
{
    public class OfferLink
    {
        public Guid OfferLinkId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool AllowDonation { get; set; }
        public decimal DonationPrice { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}