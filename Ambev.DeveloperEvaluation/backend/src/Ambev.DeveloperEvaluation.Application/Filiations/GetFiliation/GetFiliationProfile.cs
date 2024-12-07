using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Filiations.GetFiliation;

public class GetFiliationProfile : Profile
{
    public GetFiliationProfile()
    {
        CreateMap<Filiation, GetFiliationResult>();
    }
}
