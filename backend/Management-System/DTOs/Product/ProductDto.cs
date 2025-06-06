using Management_System.Models;

namespace Management_System.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}