using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.ProductTypes
{
    public class ProductType
    {
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public short Count { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}