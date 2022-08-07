using Invoices.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithProductAsync();
        Task<Product> GetWithProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllWithProductByProductIdAsync(int productId);
    }
}
