using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Management_System.DTOs.Product
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(120,ErrorMessage = "Product Name cannot be over 120 characters")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(280,ErrorMessage = "Description cannot be over 280 characters")]
        public string? Description { get; set; }
        [Required]
        [Range(typeof(decimal),"0","92281625142643375935335")]
        [DisplayFormat(DataFormatString="{N6}")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [Required]
        [Range(0,9999999999999999999)]
        public int Quantity { get; set; }
    }
}