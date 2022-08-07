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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InvoicesDbContext context)
           : base(context)
        { }

        public async Task<IEnumerable<Product>> GetAllWithProductAsync()
        {
            return await InvoiceDbContext.Products
                .Include(m => m.Id)
                .ToListAsync();
        }

        public async Task<Product> GetWithProductByIdAsync(int id)
        {
            return await InvoiceDbContext.Products
                .Include(m => m.Id)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Product>> GetAllWithProductByProductIdAsync(int productId)
        {
            return await InvoiceDbContext.Products
                .Include(m => m.Id)
                .Where(m => m.Id == productId)
                .ToListAsync();
        }


        private InvoicesDbContext InvoiceDbContext
        {
            get { return Context as InvoicesDbContext; }
        }
    }
}