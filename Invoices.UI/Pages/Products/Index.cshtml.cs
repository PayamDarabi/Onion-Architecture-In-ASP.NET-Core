using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Invoices.Core.Models;
using Invoices.Data;

namespace Invoices.UI.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Invoices.Data.InvoicesDbContext _context;

        public IndexModel(Invoices.Data.InvoicesDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
