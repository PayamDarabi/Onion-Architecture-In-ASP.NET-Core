using Invoices.Core.Models;
using Invoices.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Invoice>> GetAllWithInvoiceAsync()
        {
            return await InvoiceDbContext.Invoices
                .Include(m => m.Id)
                .ToListAsync();
        }

        public async Task<Invoice> GetWithInvoiceByIdAsync(int id)
        {
            return await InvoiceDbContext.Invoices
                .Include(m => m.Id)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Invoice>> GetAllWithInvoiceByInvoiceIdAsync(int invoiceId)
        {
            return await InvoiceDbContext.Invoices
                .Include(m => m.Id)
                .Where(m => m.Id == invoiceId)
                .ToListAsync();
        }


        private InvoicesDbContext InvoiceDbContext
        {
            get { return Context as InvoicesDbContext; }
        }
    }
}