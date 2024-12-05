using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.CreateFiliation;
using AutoMapper;

public class CreateFiliationProfile : Profile
{
    public CreateFiliationProfile()
    {
        CreateMap<CreateFiliationResult, CreateFiliationCommand>();
        CreateMap<CreateFiliationResult, CreateFiliationResponse>();
    }

    protected internal CreateFiliationProfile(string profileName) : base(profileName)
    {
    }

    protected internal CreateFiliationProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }
}