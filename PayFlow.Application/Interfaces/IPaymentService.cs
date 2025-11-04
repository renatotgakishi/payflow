using PayFlow.Application.DTOs;

namespace PayFlow.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> HandlerPaymentAsync(PaymentRequest request);
    }
}
