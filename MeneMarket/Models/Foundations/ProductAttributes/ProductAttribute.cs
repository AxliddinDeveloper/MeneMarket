using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.ProductAttributes
{
    public class ProductAttribute
    {
        public Guid ProductAttributeId { get; set; }
        public short Count { get; set; }
        public string? Size { get; set; }
        public Belong Belong { get; set; }
        public ColorType? Color { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}