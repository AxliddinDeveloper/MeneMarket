using MeneMarket.Models.Foundations.ProductAttributes;

namespace MeneMarket.Models.Foundations.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public long LastPrice { get; set; }
        public long? NewPrice { get; set; }
        public short? NumberSold { get; set; }
        public short? NumberStars { get; set; }
        public bool IsArchived { get; set; }
        public ProductType ProductType { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}