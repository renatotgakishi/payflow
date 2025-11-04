using PayFlow.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponse> HandlerPaymentAsync(PaymentRequest request);
    }
}
