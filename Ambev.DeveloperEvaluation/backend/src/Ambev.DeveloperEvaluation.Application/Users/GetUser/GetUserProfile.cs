using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

public class GetUserProfile : Profile
{
    public GetUserProfile()
    {
        CreateMap<User, GetUserResult>();
    }
}
