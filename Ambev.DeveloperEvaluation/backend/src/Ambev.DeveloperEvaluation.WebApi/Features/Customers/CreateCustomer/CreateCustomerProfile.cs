using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using AutoMapper;

public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerResult, CreateCustomerCommand>();
        CreateMap<CreateCustomerResult, CreateCustomerResponse>();
    }

    protected internal CreateCustomerProfile(string profileName) : base(profileName)
    {
    }

    protected internal CreateCustomerProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }

}
