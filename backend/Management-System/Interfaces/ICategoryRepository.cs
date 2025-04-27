using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.Category;
using Management_System.Helpers;
using Management_System.Models;

namespace Management_System.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<List<Product>> GetAllByCategoryAsync(QueryObject query);
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category> CreateAsync(Category categoryModel);
        Task<Category?> UpdateAsync(Guid id, UpdateCategoryDto categoryDto);
        Task<Category?> DeleteAsync(Guid id);
        Task<bool> CategoryExists(Guid id);
    }
}