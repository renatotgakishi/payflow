namespace PayFlow.Domain.ValueObjects
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }        
    }
}
