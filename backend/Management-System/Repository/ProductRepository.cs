using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.Product;
using Management_System.Helpers;
using Management_System.Interfaces;
using Management_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Management_System.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<Product?> DeleteAsync(Guid id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(productModel == null)
            {
                return null;
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

       

        public async  Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateAsync(Guid id, Product productModel)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if(existingProduct == null)
            {
                return null;
            }
            existingProduct.Name = productModel.Name;
            existingProduct.Description = productModel.Description;
            existingProduct.Price = productModel.Price;
            existingProduct.Image = productModel.Image;
            existingProduct.Quantity = productModel.Quantity;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}