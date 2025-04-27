using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Management_System.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(60,ErrorMessage = "Category Name cannot be over 60 characters")]
        public string? Name { get; set; }
    }
}