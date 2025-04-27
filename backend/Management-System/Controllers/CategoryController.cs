using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.Category;
using Management_System.Helpers;
using Management_System.Interfaces;
using Management_System.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesByName([FromQuery] QueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var products = await _categoryRepo.GetAllByCategoryAsync(query);
                var productsDto = products.Select(s => s.ToProductDto());
                return Ok(productsDto);
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categories = await _categoryRepo.GetAllAsync();
            var categoryDto = categories.Select(s => s.ToCategoryDto());
            return Ok(categoryDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryRepo.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        [HttpPut]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryModel = await _categoryRepo.UpdateAsync(id,updateDto);
            if(categoryModel == null)
            {
                return NotFound();
            }
            return Ok(categoryModel.ToCategoryDto());
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
            var categoryModel = await _categoryRepo.DeleteAsync(id);;
            if(categoryModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}