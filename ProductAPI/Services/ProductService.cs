using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DbContexts;
using ProductAPI.Entities;
using ProductAPI.Models;
using ProductAPI.Profiles;

namespace ProductAPI.Services;

public class ProductService : IProductService
{
    private readonly ProductContext _productContext;
    private readonly IMapper _mapper;


    public ProductService(ProductContext productContext, IMapper mapper)
    {
        _productContext = productContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var products = await _productContext.Products.ToListAsync();

        return _mapper.Map<IEnumerable<Product>>(products);

    }//await _productContext.Products.ToListAsync(); //todo: automapper

    public async Task<ProductDto?> GetProductAsync(int productId)
    {
        Product? product = await _productContext.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
        {
            return null;
        }

        var productDto = _mapper.Map<ProductDto>(product);



        return (ProductDto?)productDto;
    }

    public async Task<Product> CreateProductAsync(ProductCreationDto newProduct) 
    {


        var productToBeSaved = _mapper.Map<Product>(newProduct);

        _productContext.Products.Add((productToBeSaved));

        await _productContext.SaveChangesAsync();

        return productToBeSaved;
    }

    public async Task<Product?> UpdateProductAsync(int productId, ProductUpdateDto updatedProduct)
    {
        var product = await _productContext.Products.FirstOrDefaultAsync(c => c.Id == productId);

        if (product == null)
        {
            return null;
        }


        _mapper.Map(updatedProduct, product);



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
