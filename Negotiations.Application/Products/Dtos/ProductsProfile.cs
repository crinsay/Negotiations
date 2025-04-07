using AutoMapper;
using Negotiations.Domain.Entities;


namespace Negotiations.Application.Products.Dtos;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
    }
}
