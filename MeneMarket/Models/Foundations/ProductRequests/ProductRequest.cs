using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.ProductRequests
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserRegion { get; set; }
        public ProductRequestStatusType Status { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}