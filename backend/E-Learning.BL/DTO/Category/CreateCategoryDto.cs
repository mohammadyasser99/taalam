using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.BL.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
    }
}
