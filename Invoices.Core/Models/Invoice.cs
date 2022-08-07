using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Core.Models
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItems>();
        }
        public long Id { get; set; }
        public string BuyerName { get; set; }
        public long InvoiceNumber { get; set; }
        public string Description { get; set; }
        public decimal TotalSum { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPayableAmount { get; set; }   
        public IEnumerable<InvoiceItems> InvoiceItems { get; set; }   
    }
}
