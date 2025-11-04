using PayFlow.Domain.Entities;
using PayFlow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
