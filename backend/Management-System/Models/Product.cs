using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Management_System.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product Name must be specified")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Product Price must be specified")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage = "Product Quantity must be specified")]
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}