using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.Category;
using Management_System.DTOs.Product;
using Management_System.Models;

namespace Management_System.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Products = categoryModel.Products.Select(c => c.ToProductDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryDto categoryDto)
        {
            return new Category
            {
                Name = categoryDto.Name
            };
        }
    }
}