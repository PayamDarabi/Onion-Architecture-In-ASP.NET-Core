using Invoices.Core;
using Invoices.Core.Models;
using Invoices.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Invoice> CreateInvoice(Invoice newInvoice)
        {
            await _unitOfWork.Invoices
                .AddAsync(newInvoice);
            await _unitOfWork.CommitAsync();

            return newInvoice;
        }
        public async Task DeleteInvoice(Invoice invoice)
        {
            _unitOfWork.Invoices.Remove(invoice);

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            return await _unitOfWork.Invoices.GetAllAsync();
        }
        public async Task<Invoice> GetInvoiceById(long id)
        {
            return await _unitOfWork.Invoices.GetByIdAsync(id);
        }
        public async Task UpdateInvoice(Invoice invoiceToBeUpdated, Invoice invoice)
        {
            //invoiceToBeUpdated.Name = invoice.t;

            await _unitOfWork.CommitAsync();
        }
    }
}