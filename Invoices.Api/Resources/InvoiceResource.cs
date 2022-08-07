using Invoices.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Resources
{
    public class InvoiceResource
    {
        public InvoiceResource()
        {
            InvoiceItemResource = new List<InvoiceItemResource>();
        }
        public string BuyerName { get; set; }
        public long InvoiceNumber { get; set; }
        public string Description { get; set; }
        public decimal TotalSum { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPayableAmount { get; set; }
        public IEnumerable<InvoiceItemResource> InvoiceItemResource { get; set; }
    }
}
