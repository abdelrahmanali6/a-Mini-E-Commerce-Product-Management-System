using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.Category;
using Management_System.Helpers;
using Management_System.Interfaces;
using Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> CategoryExists(Guid id)
        {
            return _context.Categories.AnyAsync(s => s.Id == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(categoryModel == null)
            {
                return null;
            }

            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<List<Product>> GetAllByCategoryAsync(QueryObject query)
        {
            var categoryModels = _context.Categories.AsQueryable();
            List<Category> category = categoryModels.ToList();
            var catId = Guid.NewGuid();
            if(string.IsNullOrWhiteSpace(query.Name))
            {
                return null;
            }
            foreach (var x in category)
            {
                if(x.Name == query.Name)
                {
                    catId = x.Id;
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await _context.Products.Where(x => x.CategoryId == catId).Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Category?> UpdateAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = categoryDto.Name;
            existingCategory.Products = await _context.Products.Where(x => x.CategoryId == existingCategory.Id).ToListAsync();
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}