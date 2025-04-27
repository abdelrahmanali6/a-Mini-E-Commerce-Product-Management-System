using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.Product;
using Management_System.Models;

namespace Management_System.DTOs.CartItem
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}