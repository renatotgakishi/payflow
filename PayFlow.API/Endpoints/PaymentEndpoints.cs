using PayFlow.Application.DTOs;
using PayFlow.Application.Interfaces;

namespace PayFlow.API.Endpoints
{
    public static class PaymentEndpoints
    {
        public static void MapPaymentEndpoints(this WebApplication app)
        {
            app.MapPost("/payments", async (PaymentRequest request, IPaymentService service) =>
            {
                var response = await service.HandlerPaymentAsync(request);
                return Results.Ok(response);
            }).WithName("CreatePayment")
            .WithOpenApi();
            
        }

    }

}
