using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.ProductAttributes;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Foundations.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public long LastPrice { get; set; }
        public long NewPrice { get; set; }
        public short NumberSold { get; set; }
        public short NumberStars { get; set; }
        public bool IsArchived { get; set; }
        public ProductType ProductType { get; set; }
        public virtual List<ProductAttribute> ProductAttributes { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}