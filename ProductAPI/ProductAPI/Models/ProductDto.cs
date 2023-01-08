using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class ProductDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }        
        public int ProductCode { get; set; }       
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }  = string.Empty ;
        public decimal Price { get; set; } = 0 ;
    }
}
