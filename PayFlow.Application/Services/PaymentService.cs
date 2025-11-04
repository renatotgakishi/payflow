using PayFlow.Application.DTOs;
using PayFlow.Application.Interfaces;

namespace PayFlow.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentProviderFactory _paymentProviderFactory;

        public PaymentService(IPaymentProviderFactory paymentProviderFactory)
        {
            _paymentProviderFactory = paymentProviderFactory;
        }

        public async Task<PaymentResponse> HandlerPaymentAsync(PaymentRequest request)
        {
            var domainRequest = request.ToDomain();

            var provider = _paymentProviderFactory.GetProvider(domainRequest.Amount);
            var payment =  await provider.ProcessPaymentAsync(domainRequest);

            payment.Fee = provider.CalculateFee(payment.Amount);

            return new PaymentResponse
            {
                Id = 2,                
                ExternalId = payment.ExternalId,
                Status = payment.Status,
                Provider = payment.Provider,
                GrossAmount = payment.Amount,
                Fee = Math.Round(payment.Fee,2),
                NetAmount = Math.Round( payment.Amount - payment.Fee,2)
            };                        
        }
        
    }
}
