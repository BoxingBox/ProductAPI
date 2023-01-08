using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class ProductCreationDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; } = 0;
    }
}
