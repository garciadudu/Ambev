using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

public class GetCustomerProfile : Profile
{
    public GetCustomerProfile()
    {
        CreateMap<Customer, GetCustomerResult>();
    }
}
