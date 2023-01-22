using Microsoft.OpenApi.Services;
using ProductAPI.Models;

namespace ProductAPI
{
    public class ProductDataStore
    {
        public List<ProductDto> Products { get; set; }

        public static ProductDataStore Current { get; } = new ProductDataStore();   //Singleton

        public ProductDataStore()
        {
            Products = new List<ProductDto>()
            {
                // Initialize dummy data 

                new ProductDto()
                { Id = 1,
                  Name = "Small Kitchen Knife",
                  Description="A small kitchen knife used to gut fish",
                  Price= 15.60M,                
                },
                new ProductDto()
                { Id = 2,
                  Name = "Large Kitchen Knife",
                  Description="A large kitchen knife used to cut meat",
                  Price= 25.29M,
                },
                new ProductDto()
                { Id = 3,
                  Name = "Cheese serving tray",
                  Description="A serving tray used to serve cheese",
                  Price= 13.90M,
                },
                new ProductDto()
                { Id = 4,
                  Name = "Pressure cooker",
                  Description="A pressure cooker that cuts your cooking time in half",
                  Price= 75.43M,
                },
                new ProductDto()
                { Id = 5,
                  Name = "Cast-Iron pan",
                  Description="A cast iron pan used for cooking steak and fish",
                  Price= 45.10M,
                },
            };
        }

    }
}
