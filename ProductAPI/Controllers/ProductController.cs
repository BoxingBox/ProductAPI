using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Extensions;
using ProductAPI.Models;
using ProductAPI.Responses;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProductsAsync());

        }

        [HttpGet("{productId:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetProduct([Range(1, int.MaxValue)] int productId)
        {
            var productDto = await _productService.GetProductAsync(productId);

            if (productDto == null)
            {
                return NotFound("This product id does not exist");
            }

            return Ok(productDto);
        }


        [HttpPost] //GENERIC POST TO BE IMPROVED WITH ENTITY FRAMEWORK
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<IActionResult> CreateProduct(ProductCreationDto productCreation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToValidationError());

            var createdProduct = await _productService.CreateProductAsync(productCreation);

            return CreatedAtRoute("GetProduct", new { productId = createdProduct.Id }, createdProduct);

            // var product = _productContext.Products.FirstOrDefault(c => c.Id == productId);
            //
            // if (product == null)
            // {
            //     return NotFound();
            // }
            //
            // var MaxProductId = ProductDataStore.Current.Products.Max(p => p.Id); //TODO: TO BE IMPROVED
            //
            // var finalProduct = new ProductDto { Id = ++MaxProductId, Price = productCreation.Price, Description = productCreation.Description, Name = productCreation.Name };
            //
            // ProductDataStore.Current.Products.Add(finalProduct);
            //
            // return CreatedAtRoute("GetProduct", new { productId = productId }, finalProduct);

            // else return BadRequest(new { error = "Something went wrong" });
        }


        [HttpPut("{productId:int}")] //GENERIC PUT TO BE IMPROVED WITH ENTITY FRAMEWORK
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateProduct(int productId, ProductUpdateDto productUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToValidationError());

            var product = await _productService.UpdateProductAsync(productId, productUpdate);

            if (product == null)
            {
                return NotFound("This product id does not exist");
            }

            return Ok(product);
        }

        [HttpDelete("{productId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            return NoContent();
        }
    }
}
