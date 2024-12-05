using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Filiaitions.GetFiliation;

public class GetFiliationProfile : Profile
{
    public GetFiliationProfile()
    {
        CreateMap<Filiation, GetFiliationResult>();
    }
}
