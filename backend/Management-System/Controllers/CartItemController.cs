using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.CartItem;
using Management_System.Interfaces;
using Management_System.Mappers;
using Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepo;

        public CartItemController(ICartItemRepository cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult>  GetById([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItem = await _cartItemRepo.GetByIdAsync(id);
            if(cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem.ToCartItemDto());
        }

        
        [HttpPut]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] List<Product> updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItemModel = await _cartItemRepo.UpdateAsync(id,updateDto);
            if(cartItemModel == null)
            {
                return NotFound();
            }
            return Ok(cartItemModel.ToCartItemDto());
        }
        [HttpDelete]
        [Authorize]
        [Route("{id:Guid}")]
        public async Task<IActionResult>  Delete([FromRoute] Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cartItemModel = await _cartItemRepo.DeleteAsync(id);;
            if(cartItemModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}