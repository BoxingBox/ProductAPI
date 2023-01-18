using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Entities
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } 

        [Required]
        [MaxLength(300)]
        public string? Description { get; set; } 

        [Required]
        public decimal Price { get; set; } = 0;

        public Products(string name)
        {
            Name = name;
        }
    }
}
