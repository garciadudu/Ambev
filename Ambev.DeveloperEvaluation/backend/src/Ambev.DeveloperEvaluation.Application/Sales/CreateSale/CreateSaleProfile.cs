using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, CreateSaleDTO>()
            .ForAllMembers(x => x.Ignore());
            //.ForMember(dest => dest.Branch, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Branch) ? "" : x.Branch))
            //.ForMember(dest => dest.Customer,
            //    opt => opt.MapFrom(x => new CreateCustomerDTO()
            //    {
            //        Id = x.Customer.Id,
            //    }))
            //.ForMember(dest => dest.Products,
            //    opt => opt.MapFrom(x => x.Products.Select(y => new CreateProductDTO()
            //    {
            //        Id = y.Id.ToString(),
            //        Descriptions = y.Descriptions,
            //        Discounts = y.Discounts,
            //        Price = y.Price,
            //        Quantity = y.Quantity,
            //        TotalAmount = y.TotalAmount
            //    })));

        CreateMap<CreateSaleDTO, Sale>()
            .ForMember(dest => dest.Branch, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Branch) ? "" : x.Branch))
            .ForMember(dest => dest.Customer,
                opt => opt.MapFrom(x => new Customer()
                {
                    Id = x.Customer.Id,
                }))
            .ForMember(dest => dest.Products,
                opt => opt.MapFrom(x => x.Products.Select(y => new Product()
                {
                    Descriptions = y.Descriptions,
                    Discounts = y.Discounts,
                    Price = y.Price,
                    Quantity = y.Quantity,
                    TotalAmount = y.TotalAmount
                })
            ));

        CreateMap<CreateProductCommand, CreateProductDTO>()
            .ConstructUsing(dest => new CreateProductDTO()
            {
                Id = new Guid(dest.Id),
                Descriptions = dest.Descriptions,
                Quantity = dest.Quantity,
                Price = dest.Price,
                Discounts = dest.Discounts,
                TotalAmount = dest.TotalAmount,
            });

        CreateMap<CreateProductDTO, Product>()
            .ConstructUsing(dest => new Product()
            {
                Descriptions = dest.Descriptions,
                Quantity = dest.Quantity,
                Price = dest.Price,
                Discounts = dest.Discounts,
                TotalAmount = dest.TotalAmount,
            });
    }
}
