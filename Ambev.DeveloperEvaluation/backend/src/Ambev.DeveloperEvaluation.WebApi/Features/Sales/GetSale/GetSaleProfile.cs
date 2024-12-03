using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<Guid, Application.Products.GetProduct.GetProductCommand>()
            .ConstructUsing(id => new Application.Products.GetProduct.GetProductCommand(id));

    }
}
