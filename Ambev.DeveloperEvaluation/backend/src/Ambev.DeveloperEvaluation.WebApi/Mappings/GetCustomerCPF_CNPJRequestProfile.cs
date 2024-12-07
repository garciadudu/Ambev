using Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerCPF_CNPJ;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class GetCustomerCPF_CNPJRequestProfile : Profile
{
    public GetCustomerCPF_CNPJRequestProfile()
    {
        CreateMap<GetCustomerCPF_CNPJRequest, GetCustomerCPF_CNPJCommand>();
    }
}