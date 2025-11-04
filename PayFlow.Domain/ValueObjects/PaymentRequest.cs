using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Domain.ValueObjects
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }        
    }
}
