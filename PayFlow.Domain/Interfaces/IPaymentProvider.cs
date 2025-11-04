using PayFlow.Domain.Entities;
using PayFlow.Domain.ValueObjects;

namespace PayFlow.Domain.Interfaces
{
    //designer pattern: Strategy
    public interface IPaymentProvider 
    {
        Task<Payment> ProcessPaymentAsync(PaymentRequest request);    
        bool IsAvailable();
        decimal CalculateFee(decimal amount);
    }
}
