using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            return Ok(ProductDataStore.Current.Products);
        }

        [HttpGet("{productId}",Name="GetProduct")]

        public ActionResult<IEnumerable<ProductDto>> GetProduct(int productId)
        {
            if (ModelState.IsValid)
            { 
            ProductDto ?Selection = ProductDataStore.Current.Products.FirstOrDefault(c => c.Id == productId);

            if (Selection == null) { return NotFound(); }
            

            return Ok(Selection);
            }
            else 
            {
                throw new Exception("ID must be a positive number");
            }
        }

        [HttpPost]                                                          //GENERIC POST TO BE IMPROVED
        public ActionResult<ProductDto> CreateProduct(int productId, ProductCreationDto productCreation)
        {
            ProductDto ?Product = ProductDataStore.Current.Products.FirstOrDefault(c => c.Id == productId);

            if (Product == null) { return NotFound(); }

            var MaxProductId = ProductDataStore.Current.Products.Max(p => p.Id);         //TO BE IMPROVED

            var finalProduct = new ProductDto
            {
                Id = ++MaxProductId,
                Price = productCreation.Price,
                Description = productCreation.Description,
                Name = productCreation.Name
            };

            ProductDataStore.Current.Products.Add(finalProduct);

            return CreatedAtRoute("GetProduct", new { productId = productId }, finalProduct);

        }
    }
}
