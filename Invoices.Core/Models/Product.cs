using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Core.Models
{
    public class Product
    {
        public Product()
        {
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
