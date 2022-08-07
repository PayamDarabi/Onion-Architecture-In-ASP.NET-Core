using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Resources
{
    public class SaveInvoiceItemResource
    {
        public SaveInvoiceItemResource()
        {
        }
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}
