using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

public class DeleteCustomerProfile : Profile
{
    public DeleteCustomerProfile()
    {
        CreateMap<Guid, Application.Customers.DeleteCustomer.DeleteCustomerCommand>()
            .ConstructUsing(id => new Application.Customers.DeleteCustomer.DeleteCustomerCommand(id));
    }
}
