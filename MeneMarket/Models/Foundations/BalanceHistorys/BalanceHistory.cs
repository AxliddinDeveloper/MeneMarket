using System.Text.Json.Serialization;
using MeneMarket.Models.Foundations.Users;

namespace MeneMarket.Models.Foundations.BalanceHistorys
{
    public class BalanceHistory
    {
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}