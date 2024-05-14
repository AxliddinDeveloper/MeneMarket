using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Comments;
using MeneMarket.Models.Foundations.ImageMetadatas;
using MeneMarket.Models.Foundations.OfferLinks;
using MeneMarket.Models.Foundations.ProductTypes;

namespace MeneMarket.Models.Foundations.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal ScidPrice { get; set; }
        public decimal AdvertisingPrice { get; set; }
        public short NumberSold { get; set; }
        public int Count { get; set; }
        public bool IsArchived { get; set; }
        public bool IsLiked {  get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<OfferLink> OfferLinks { get; set; }
        public virtual ICollection<ImageMetadata> ImageMetadatas { get; set; }
    }
}