using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleResult, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
    }

    protected internal CreateSaleProfile(string profileName) : base(profileName)
    {
    }

    protected internal CreateSaleProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }
}