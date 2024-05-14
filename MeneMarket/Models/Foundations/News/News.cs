namespace MeneMarket.Models.Foundations.News
{
    public class News
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public string imageFilePath { get; set; }
    }
}