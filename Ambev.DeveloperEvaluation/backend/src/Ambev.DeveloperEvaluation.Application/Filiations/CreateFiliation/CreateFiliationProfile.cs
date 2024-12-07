using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

public class CreateFiliationProfile : Profile
{
    public CreateFiliationProfile()
    {
        CreateMap<CreateFiliationCommand, Filiation>();
        CreateMap<Filiation, CreateFiliationResult>();

        CreateMap<CreateFiliationDTO, CreateFiliationCommand>();
        CreateMap<CreateFiliationCommand, CreateFiliationDTO>()
            .ConstructUsing(customer => new CreateFiliationDTO());
    }
}
