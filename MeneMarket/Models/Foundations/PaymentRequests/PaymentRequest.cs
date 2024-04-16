namespace MeneMarket.Models.Foundations.PaymentRequests
{
    public class PaymentRequest
    {
        public Guid Id { get; set; }
        public ulong Amount { get; set; }
        public ulong CardNumber { get; set; }
        public bool IsPayable { get; set; }
        public Guid UserId { get; set; }
    }
}