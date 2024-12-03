using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
        CreateMap<Product, CreateProductResult>();

        CreateMap<Product, CreateProductDTO>()
            .ConstructUsing(product => new CreateProductDTO()
            {
                Id = product.Id,
                Descriptions = product.Descriptions,
                Discounts = product.Discounts,
                Price = product.Price,
                Quantity = product.Quantity,
                TotalAmount = product.TotalAmount
            });
    }
}
