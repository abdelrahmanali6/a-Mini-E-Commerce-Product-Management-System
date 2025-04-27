using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.Data;
using Management_System.DTOs.CartItem;
using Management_System.Interfaces;
using Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Management_System.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ApplicationDBContext _context;
        public CartItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateAsync()
        {
            var cartItemModel = new CartItem();
            await _context.CartItems.AddAsync(cartItemModel);
            await _context.SaveChangesAsync();
            return cartItemModel.Id;
        }

        public async Task<CartItem?> DeleteAsync(Guid id)
        {
            var cartItemModel = await _context.CartItems.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(cartItemModel == null)
            {
                return null;
            }

            _context.CartItems.Remove(cartItemModel);
            await _context.SaveChangesAsync();
            return cartItemModel;
        }

        public async  Task<CartItem?> GetByIdAsync(Guid id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<CartItem?> UpdateAsync(Guid id, List<Product> productsModel)
        {
            var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(existingCartItem == null || productsModel == null)
            {
                return null;
            }
            existingCartItem.Products = productsModel;
            await _context.SaveChangesAsync();
            return existingCartItem;
        }
    }
}