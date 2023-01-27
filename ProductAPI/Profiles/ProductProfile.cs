using AutoMapper;
using ProductAPI.DbContexts;
using ProductAPI.Entities;
using ProductAPI.Models;

namespace ProductAPI.Profiles
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductCreationDto, Product>().ReverseMap();

        }
    }
}
