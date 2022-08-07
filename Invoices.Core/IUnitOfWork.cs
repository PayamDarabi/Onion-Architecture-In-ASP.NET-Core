using Invoices.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Invoices.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        IInvoiceRepository Invoices { get; }
        Task<int> CommitAsync();
    }
}
