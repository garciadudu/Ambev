using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using AutoMapper;

public class CreateProductProfile : Profile
{
    public CreateProductProfile()
    {
        CreateMap<CreateProductResult, CreateProductCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
    
    protected internal CreateProductProfile(string profileName) : base(profileName)
    {
    }

    protected internal CreateProductProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }
}