using Moq;
using PayFlow.Application.DTOs;
using PayFlow.Application.Factories;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Services;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.ValueObjects;
using Xunit;

namespace PayFlow.Tests
{
    public class PaymentServiceTests
    {
        [Fact]
        public async Task HandlerPaymentAsync_ShouldReturnExpectedResponse()
        {
            // Arrange
            var domainRequest = new PayFlow.Domain.ValueObjects.PaymentRequest
            {
                Amount = 120.50m,
                Currency = "BRL"
            };
            
            var mockProvider = new Mock<IPaymentProvider>();
            mockProvider.Setup(p => p.ProcessPaymentAsync(It.IsAny<PayFlow.Domain.ValueObjects.PaymentRequest>()))
                        .ReturnsAsync((PayFlow.Domain.ValueObjects.PaymentRequest r) => new Payment
                        {
                            Amount = r.Amount,
                            Currency = r.Currency,
                            ExternalId = "ABC123",
                            Status = "Approved",
                            Provider = "SecurePay"
                        });

            mockProvider.Setup(p => p.CalculateFee(It.IsAny<decimal>()))
                        .Returns(4.01m);

            var mockFactory = new Mock<IPaymentProviderFactory>();
            
            mockFactory.Setup(f => f.GetProvider(It.IsAny<decimal>()))
                       .Returns(mockProvider.Object);

            var service = new PaymentService(mockFactory.Object);

            var dtoRequest = new PayFlow.Application.DTOs.PaymentRequest
            {
                Amount = 120.50m,
                Currency = "BRL"
            };

            // Act
            var response = await service.HandlerPaymentAsync(dtoRequest);

            // Assert
            Assert.Equal("ABC123", response.ExternalId);
            Assert.Equal("Approved", response.Status);
            Assert.Equal("SecurePay", response.Provider);
            Assert.Equal(120.50m, response.GrossAmount);
            Assert.Equal(4.01m, response.Fee);
            Assert.Equal(116.49m, response.NetAmount);
        }
    }
}