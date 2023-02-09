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

    private ProductController _controller;
    private Mock<IProductService> _mockProductService;

    public ProductControllerTests()
    {
        _mockProductService = new Mock<IProductService>();
        _controller = new ProductController(_mockProductService.Object);
    }

    [Fact]
    
    public async Task UpdateProduct_ReturnsNotFound_WhenProductDoesNotExist()
    {
        int productId = 1;
        var productUpdate = new ProductUpdateDto();

        var result = await _controller.UpdateProduct(productId, productUpdate);

        result.Should().BeOfType<NotFoundObjectResult>()
              .Which.Value.Should().BeOfType<string>()
              .And.Subject.Should().Be("This product id does not exist");
    }

    [Fact]
    public async Task UpdateProduct_Returns_NotFound_When_Given_Wrong_Id()
    {
        // Arrange
        
        var productServiceMock = new Mock<IProductService>();
        var controller = new ProductController(productServiceMock.Object);
        var productId = Int32.MaxValue;
        var productUpdate = new ProductUpdateDto
        { Name = "Test Product", Description="Test Desc", Price = 10 };

        // Act
        var result = await controller.UpdateProduct(productId, productUpdate);
        

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        var okResult = result as NotFoundObjectResult;

        okResult.StatusCode.Should().Be(404);
        okResult.Value.Should().BeOfType<String>();
    }

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

    

    [Fact]
    public async Task PostProduct_WhenModelStateIsInvalid_ReturnsBadRequest()
    {
        // Arrange
        var productCreation = new ProductCreationDto
        {
            Name = "",
            Description = "Description for Product 1",
            Price = 100
        };
        var productServiceMock = new Mock<IProductService>();
        var controller = new ProductController(productServiceMock.Object);
        controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = await controller.CreateProduct(productCreation) as BadRequestObjectResult;

        // Assert
        productServiceMock.Verify(x => x.CreateProductAsync(It.IsAny<ProductCreationDto>()), Times.Never);
        result.Should().NotBeNull();
        
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnNoContent()
    {
        // Arrange
        var mockProductService = new Mock<IProductService>();
        mockProductService.Setup(x => x.DeleteProductAsync(It.IsAny<int>()))
            .Returns(Task.FromResult((bool?)null));
        var controller = new ProductController(mockProductService.Object);

        // Act
        var result = await controller.DeleteProduct(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
        mockProductService.Verify(x => x.DeleteProductAsync(1), Times.Once());
    }



}

