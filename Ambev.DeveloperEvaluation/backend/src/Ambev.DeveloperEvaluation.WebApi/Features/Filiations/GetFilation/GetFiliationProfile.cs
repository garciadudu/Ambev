using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiations.GetFiliation;

public class GetFiliationProfile : Profile
{
    public GetFiliationProfile()
    {
        CreateMap<Guid, Application.Filiaitions.GetFiliation.GetFiliationCommand>()
            .ConstructUsing(id => new Application.Filiaitions.GetFiliation.GetFiliationCommand(id));
    }
}