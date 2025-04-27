using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Management_System.DTOs.Product;

namespace Management_System.DTOs.CartItem
{
    public class UpdateCartItemDto
    {
        public List<ProductDto> Products { get; set; }
    }
}