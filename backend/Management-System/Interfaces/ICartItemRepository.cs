using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.CartItem;
using Management_System.Models;

namespace Management_System.Interfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync();
        Task<CartItem?> UpdateAsync(Guid id, List<Product> productsModel);
        Task<CartItem?> DeleteAsync(Guid id);
    }
}