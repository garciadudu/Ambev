using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;

public class GetCustomerCPF_CNPJProfile : Profile
{
    public GetCustomerCPF_CNPJProfile()
    {
        CreateMap<Customer, GetCustomerCPF_CNPJResult>();
    }
}
