using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Api.Resources
{
    public class SaveProductResource
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
