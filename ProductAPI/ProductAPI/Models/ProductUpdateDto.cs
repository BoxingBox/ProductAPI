using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class ProductUpdateDto
    {

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 50 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 500000)]
        public decimal Price { get; set; } = 0;
    }
}

