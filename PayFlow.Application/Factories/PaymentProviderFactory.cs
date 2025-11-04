using PayFlow.Application.Interfaces;
using PayFlow.Domain.Interfaces;
using PayFlow.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Application.Factories
{
    public class PaymentProviderFactory : IPaymentProviderFactory
    {
      
        private readonly IEnumerable<IPaymentProvider> _providers;

        public PaymentProviderFactory(IEnumerable<IPaymentProvider> providers)
        {
            _providers = providers;
        }

        public IPaymentProvider GetProvider(decimal amount)
        {
            var primary = amount <= 100
                ? _providers.FirstOrDefault(p => p is FastPayProvider && p.IsAvailable())
                : _providers.FirstOrDefault(p => p is SecurePayProvider && p.IsAvailable());

            var fallback = amount <= 100
                ? _providers.FirstOrDefault(p => p is SecurePayProvider && p.IsAvailable())
                : _providers.FirstOrDefault(p => p is FastPayProvider && p.IsAvailable());

            return primary ?? fallback ?? throw new Exception("Nenhum provedor disponível");
        }



    }
}
