using PayFlow.Application.Factories;
using PayFlow.Application.Interfaces;
using PayFlow.Application.Services;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Providers;

namespace PayFlow.API.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPayFlowService(this IServiceCollection services)
        {
            services.AddScoped<IPaymentProvider, FastPayProvider>();
            services.AddScoped<IPaymentProvider, SecurePayProvider>();
            services.AddScoped<PaymentProviderFactory>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
