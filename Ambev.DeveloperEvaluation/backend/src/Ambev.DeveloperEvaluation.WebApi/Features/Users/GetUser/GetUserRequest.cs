namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetUserRequest
{
    public Guid Id { get; set; }
}
