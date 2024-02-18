using MeneMarket.Models.Foundations.ImageMetadatas;
using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.ProductAttributes;

namespace MeneMarket.Models.Foundations.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal ScidPrice { get; set; }
        public decimal AdvertisingPrice { get; set; }
        public short NumberSold { get; set; }
        public short NumberStars { get; set; }
        public string ProductOwner { get; set; }
        public bool IsArchived { get; set; }
        public ProductType ProductType { get; set; }
        public virtual ICollection<ImageMetadata> ImageMetadatas { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<OfferLink> OfferLinks { get; set; }
    }
}