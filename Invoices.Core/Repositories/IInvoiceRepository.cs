using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Invoices.Core.Models;

namespace Invoices.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetAllWithInvoiceAsync();
        Task<Invoice> GetWithInvoiceByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllWithInvoiceByInvoiceIdAsync(int invoiceId);
    }
}
