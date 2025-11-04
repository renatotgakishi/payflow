using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Domain.Entities
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public decimal Fee { get; set; }

        public Payment() { }

        public Payment(decimal amount, string currency, string externalId, string status, string provider)
        {
            Amount = amount;
            Currency = currency;
            ExternalId = externalId;
            Status = status;
            Provider = provider;
        }
    }
}
