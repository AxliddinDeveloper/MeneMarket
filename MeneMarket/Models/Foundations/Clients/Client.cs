using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.OfferLinks;

namespace MeneMarket.Models.Foundations.Clients
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string IpAddress { get; set; }
        public StatusType StatusType { get; set; }
        public Guid OfferLinkId { get; set; }
        [JsonIgnore]
        public virtual OfferLink OfferLink { get; set; }
    }
}