using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.CreateFiliation;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateFiliationRequestProfile : Profile
{
    public CreateFiliationRequestProfile()
    {
        CreateMap<CreateFiliationRequest, CreateFiliationCommand>();
    }
}