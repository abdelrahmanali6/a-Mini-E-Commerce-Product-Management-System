using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.Product;
using Management_System.Helpers;
using Management_System.Interfaces;
using Management_System.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var products = await _productRepo.GetAllAsync();
            var productDto = products.Select(s => s.ToProductDto());
            return Ok(productDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productRepo.GetByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        [Authorize]
        [Route("{categoryId:Guid}")]
        public async Task<IActionResult> CreateProduct([FromRoute] Guid categoryId,[FromBody] CreateProductDto productDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!await _categoryRepo.CategoryExists(categoryId))
            {
                return BadRequest("Category does not exist");
            }
            var productModel = productDto.ToProductFromCreateDto(categoryId);
            await _productRepo.CreateAsync(productModel);
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }

        [HttpPut]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productModel = await _productRepo.UpdateAsync(id,updateDto.ToProductFromUpdateDto());
            if(productModel == null)
            {
                return NotFound();
            }
            return Ok(productModel.ToProductDto());
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productModel = await _productRepo.DeleteAsync(id);
            if(productModel == null)
            {
                return NotFound("Product does not exist");
            }

           
            return Ok();
        }
    }
}