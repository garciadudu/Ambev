using Ambev.DeveloperEvaluation.Application.Filiations.GetFiliation;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiations.GetFiliation;

public class GetFiliationProfile : Profile
{
    public GetFiliationProfile()
    {
        CreateMap<Guid, Application.Filiations.GetFiliation.GetFiliationCommand>()
            .ConstructUsing(id => new Application.Filiations.GetFiliation.GetFiliationCommand(id));


        CreateMap<GetFiliationResult, GetFiliationCommand>();
        CreateMap<GetFiliationResult, GetFiliationResponse>();
    }


    protected internal GetFiliationProfile(string profileName) : base(profileName)
    {
    }

    protected internal GetFiliationProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }


}