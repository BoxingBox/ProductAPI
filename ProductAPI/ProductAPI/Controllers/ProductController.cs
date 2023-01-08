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

        [HttpGet]
        [Route("{productId}")]
        public ActionResult<IEnumerable<ProductDto>> GetProduct(int productId)
        {
            ProductDto Selection = ProductDataStore.Current.Products.FirstOrDefault(c => c.Id == productId);

            if (Selection == null) { return NotFound(); }

            return Ok(Selection);
        }
    }
}
