namespace Common.Infraestructure.Models;

public class AuthenticationModel
{    

    public string Message { get; set; } = default!;
    public bool IsAuthenticated { get; set; }    
    public IAuthenticatedUser User { get; set; } = default!;
    public TokenModel AccessToken { get; set; } = default!;
}
