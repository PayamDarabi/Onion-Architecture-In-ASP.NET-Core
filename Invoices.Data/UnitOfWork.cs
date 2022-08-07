using Invoices.Core;
using Invoices.Core.Repositories;
using Invoices.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InvoicesDbContext _context;
        private ProductRepository _productRepository;
        private InvoiceRepository _invoiceRepository;

        public UnitOfWork(InvoicesDbContext context)
        {
            this._context = context;
        }

        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IInvoiceRepository Invoices => _invoiceRepository = _invoiceRepository ?? new InvoiceRepository(_context);

        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}