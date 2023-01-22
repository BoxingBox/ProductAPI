using Microsoft.EntityFrameworkCore;
using ProductAPI.DbContexts;
using ProductAPI.Entities;
using ProductAPI.Models;

namespace ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _productContext;

    public ProductService(ProductContext productContext)
    {
        _productContext = productContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync() => await _productContext.Products.ToListAsync(); //todo: automapper

    public async Task<ProductDto?> GetProductAsync(int productId)
    {
        Product? product = await _productContext.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
        {
            return null;
        }

        var productDto = new ProductDto //todo: automapper
        {
            Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price
        };

        return productDto;
    }

    public async Task<Product> CreateProductAsync(ProductCreationDto newProduct) //todo: automapper
    {
        var productToBeSaved = new Product(newProduct.Name) { Description = newProduct.Description, Price = newProduct.Price };

        _productContext.Products.Add(productToBeSaved);

        await _productContext.SaveChangesAsync();

        return productToBeSaved;
    }

    public async Task<Product?> UpdateProductAsync(int productId, ProductUpdateDto updatedProduct)//todo: automapper
    {
        var product = await _productContext.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
        {
            return null;
        }

        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
        product.Name = updatedProduct.Name;

        await _productContext.SaveChangesAsync();

        return product;
    }

    public async Task<bool?> DeleteProductAsync(int productId)
    {
        try
        {
            var product = await _productContext.Products.FirstOrDefaultAsync(c => c.Id == productId);

            if (product == null)
            {
                return null;
            }

            _productContext.Products.Remove(product);

            await _productContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
