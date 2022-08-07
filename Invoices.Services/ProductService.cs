using Invoices.Core;
using Invoices.Core.Models;
using Invoices.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Product
             .AddAsync(newProduct);
            await _unitOfWork.CommitAsync();

            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Product.GetAllAsync();
        }

        public async Task<Product> GetProductById(long id)
        {
            return await _unitOfWork.Product.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
