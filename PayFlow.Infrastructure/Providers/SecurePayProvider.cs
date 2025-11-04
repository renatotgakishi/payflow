using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Infrastructure.Providers
{
    public class SecurePayProvider : IPaymentProvider
    {
        public decimal CalculateFee(decimal amount)
        {
            //return Math.Round(amount * 0.0299M + 0.40M, 3);
            //var percentual = Math.Round(amount * 0.0299M, 3); // arredonda para 3 casas
            //return Math.Round(percentual + 0.40M, 2);
            
            // mas nao acho que ta certo
            return Math.Ceiling((amount * 0.0299M + 0.40M) * 100) / 100;
        }
        
        public bool IsAvailable() => true;

        public Task<Payment> ProcessPaymentAsync(PaymentRequest request) // Altera para async Task<Payment>
        {
            var payload = new
            {
                amount_cents = (int)(request.Amount * 100),
                currency_code = request.Currency,
                client_reference = "ORD-20251022"
            };
            var response = new
            {
                transaction_id = "SP-19283",
                result = "success"
            };
           
            var payment = new Payment(request.Amount, request.Currency, response.transaction_id, response.result == "success" ? "approved" : "rejected", "SecurePay");
            return Task.FromResult(payment); // Retorna uma Task concluída com o pagamento

        }
    }
}
