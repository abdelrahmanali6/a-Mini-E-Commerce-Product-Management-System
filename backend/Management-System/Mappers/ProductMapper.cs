using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Controllers;
using Management_System.DTOs.Product;
using Management_System.Models;

namespace Management_System.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                Image = productModel.Image,
                Quantity = productModel.Quantity,
                CategoryId = productModel.CategoryId
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductDto productDto,Guid categId)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Image = productDto.Image,
                Quantity = productDto.Quantity,
                CategoryId = categId
            };
        }

        public static Product ToProductFromUpdateDto(this UpdateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Image = productDto.Image,
                Quantity = productDto.Quantity,
            };
        }
        public static Product ToProductFromProductDto(this ProductDto productDto,Guid id)
        {
            return new Product
            {
                Id = id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Image = productDto.Image,
                Quantity = productDto.Quantity,
                CategoryId = productDto.CategoryId
            };
        }
    }
}