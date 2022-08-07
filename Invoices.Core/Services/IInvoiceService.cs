using Invoices.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Core.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoiceById(long id);
        Task<Invoice> CreateInvoice(Invoice newInvoice);
        Task UpdateInvoice(Invoice invoiceToBeUpdated, Invoice invoice);
        Task DeleteInvoice(Invoice invoice);
    }
}
