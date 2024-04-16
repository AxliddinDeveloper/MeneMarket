using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Products;

namespace MeneMarket.Models.Foundations.Comments
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string IpAddress { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}