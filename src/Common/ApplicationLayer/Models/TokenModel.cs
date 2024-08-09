namespace Common.Infraestructure.Models;

public class TokenModel
{
    public string Token { get; set; } = default!;
    public string? RefreshToken { get; set; }
    public DateTime TokenDateExpiration { get; set; }
    public DateTime? RefreshTokenDateExpiration { get; set; }
}
