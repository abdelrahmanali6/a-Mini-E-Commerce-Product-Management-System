using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.CartItem;
using Management_System.Models;

namespace Management_System.Mappers
{
    public static class CartItemMapper
    {
        public static CartItemDto ToCartItemDto(this CartItem cartItemModel)
        {
            return new CartItemDto
            {
               Id = cartItemModel.Id,
               Products = cartItemModel.Products.Select(c => c.ToProductDto()).ToList()
            };
        }
        public static CartItem ToCartItemFromCreateDto(this CreateCartItemDto cartItemDto)
        {
            return new CartItem
            {
                
            };
        }

    }
}