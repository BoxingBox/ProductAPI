using Moq;
using ProductAPI.Controllers;
using ProductAPI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Tests.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _productServiceMock = new();

    [Fact]
    public async Task GetProduct_WhenCalled_ReturnsNotFound()
    {
        // Arrange
        _productServiceMock.Setup(service => service.GetProductAsync(It.IsAny<int>())).ReturnsAsync(() => null!);
        var productController = new ProductController(_productServiceMock.Object);

        // Act
        var result = await productController.GetProduct(1) as ObjectResult;
        var result2 = await productController.GetProduct(2) as ObjectResult;

        // Assert
        result.Should().NotBeNull();
        result?.StatusCode.Should().Be(StatusCodes.Status404NotFound);

        result2.Should().NotBeNull();
        result2?.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task GetProduct_WhenCalled_ReturnsOkWithCorrectObject()
    {
        // Arrange
        var myProduct = new ProductDto { Id = 1, Name = "asdfsadasd", Description = "dfadsfdsaf", Price = 100 };
        _productServiceMock.Setup(service => service.GetProductAsync(It.IsAny<int>())).ReturnsAsync(() => null!);
        _productServiceMock.Setup(service => service.GetProductAsync(1)).ReturnsAsync(() => myProduct);
        var productController = new ProductController(_productServiceMock.Object);

        // Act
        var result = await productController.GetProduct(1) as ObjectResult;
        var result2 = await productController.GetProduct(2) as ObjectResult;

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Value.Should().BeEquivalentTo(myProduct);

        result2.Should().NotBeNull();
        result2?.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}
