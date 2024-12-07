using Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerCPF_CNPJ;

public class GetCustomerCPF_CNPJProfile : Profile
{
    public GetCustomerCPF_CNPJProfile()
    {
        CreateMap<string, Application.Customers.GetCustomerCPF_CNPJ.GetCustomerCPF_CNPJCommand>()
            .ConstructUsing(id => new Application.Customers.GetCustomerCPF_CNPJ.GetCustomerCPF_CNPJCommand(id));

        CreateMap<GetCustomerCPF_CNPJResult, GetCustomerCPF_CNPJCommand>();
        CreateMap<GetCustomerCPF_CNPJResult, GetCustomerCPF_CNPJResponse>();
    }

    protected internal GetCustomerCPF_CNPJProfile(string profileName) : base(profileName)
    {
    }

    protected internal GetCustomerCPF_CNPJProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }

}
