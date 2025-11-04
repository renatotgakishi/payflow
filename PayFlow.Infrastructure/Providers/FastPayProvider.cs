using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.ValueObjects;

namespace PayFlow.Infrastructure.Providers
{
    public class FastPayProvider : IPaymentProvider
    {
        public decimal CalculateFee(decimal amount)
        {
            // return Math.Round(amount * 0.0349M, 3);
            return Math.Ceiling((amount * 0.0349M) * 100) / 100;
        }

        public bool IsAvailable() => true;

        public  Task<Payment> ProcessPaymentAsync(PaymentRequest request)
        {
            var payload = new
            {
                transaction_amount = request.Amount,
                currency = request.Currency,
                payer = new {email="cliente@teste.com"},
                installments = 1,
                description = "Compra via FastPay",
            };

            var response = new
            {
                id = "FP-88512",
                status = "aproved",
                status_detail = "pagamento aprovado"
            };

            var payment = new Payment(request.Amount, request.Currency, response.id, response.status, "FastPay");
            return Task.FromResult(payment);
        }
    }
}
