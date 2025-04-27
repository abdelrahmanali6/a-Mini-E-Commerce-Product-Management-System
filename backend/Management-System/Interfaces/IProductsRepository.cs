using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.Product;
using Management_System.Models;

namespace Management_System.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task<Product> CreateAsync(Product productModel);
        Task<Product?> UpdateAsync(Guid id, Product productModel);
        Task<Product?> DeleteAsync(Guid id);
    }
}