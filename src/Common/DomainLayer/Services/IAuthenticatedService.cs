namespace Common.Domain.Services;

public interface IAuthenticatedService
{
    string Id { get; }
    string Username { get; }
    string Email { get; }
    bool IsAuthenticated { get; }
}
