using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Core.Models
{
    public class InvoiceItems
    {
        public InvoiceItems()
        {
        }

        public long Id { get; set; }
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}
