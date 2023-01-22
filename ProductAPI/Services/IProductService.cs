using ProductAPI.Entities;
using ProductAPI.Models;

namespace ProductAPI.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<ProductDto?> GetProductAsync(int productId);
    Task<Product> CreateProductAsync(ProductCreationDto newProduct);
    Task<Product?> UpdateProductAsync(int productId, ProductUpdateDto newProduct);
    Task<bool?> DeleteProductAsync(int productId);
}
