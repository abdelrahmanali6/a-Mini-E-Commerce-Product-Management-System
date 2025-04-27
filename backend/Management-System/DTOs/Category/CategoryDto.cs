namespace Management_System.DTOs.Product
{
    public class CategoryDto
    {
        public string? Name { get; set; }
        public Guid Id { get; set; }
        public List<ProductDto>? Products { get; set; }
    }
}