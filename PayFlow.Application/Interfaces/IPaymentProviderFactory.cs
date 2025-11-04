using PayFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Application.Interfaces
{
    public interface IPaymentProviderFactory
    {
        IPaymentProvider GetProvider(decimal amount);
    }
}
