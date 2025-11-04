using PayFlow.Domain.Interfaces;

namespace PayFlow.Application.Interfaces
{
    public interface IPaymentProviderFactory
    {
        IPaymentProvider GetProvider(decimal amount);
    }
}
