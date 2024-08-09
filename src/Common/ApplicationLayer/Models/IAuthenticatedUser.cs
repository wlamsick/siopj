namespace Common.Infraestructure.Models;

public interface IAuthenticatedUser
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string? UserType { get; set; }
    public string? Account { get; set; }
    public string? Company { get; set; }
}
