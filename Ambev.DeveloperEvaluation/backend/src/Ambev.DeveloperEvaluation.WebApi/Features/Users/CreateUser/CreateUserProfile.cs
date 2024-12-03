using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<CreateUserResult, CreateUserResponse>();
    }

    protected internal CreateUserProfile(string profileName) : base(profileName)
    {
    }

    protected internal CreateUserProfile(string profileName, Action<IProfileExpression> configurationAction) : base(profileName, configurationAction)
    {
    }
}
