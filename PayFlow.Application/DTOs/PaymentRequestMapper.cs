namespace PayFlow.Application.DTOs
{
    public static class PaymentRequestMapper
    {
        public static Domain.ValueObjects.PaymentRequest ToDomain(this PaymentRequest dto)
        {
            return new Domain.ValueObjects.PaymentRequest
            {
                Amount = dto.Amount,
                Currency = dto.Currency
            };
        }
    }
}
