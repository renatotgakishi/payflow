using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayFlow.Application.DTOs
{
    public class PaymentResponse
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Status { get; set; }
        public string Provider { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Fee { get; set; }
        public decimal NetAmount { get; set; }

    }
}
