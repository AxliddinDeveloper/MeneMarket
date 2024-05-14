using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.ImageMetadatas
{
    public class ImageMetadata
    {
        public Guid Id { get; set; }
        public string LowImageFilePath { get; set; }
        public string MediumImageFilePath { get; set; }
        public string HightImageFilePath { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}