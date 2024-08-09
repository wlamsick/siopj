using System.ComponentModel.DataAnnotations;

namespace Common.Infraestructure.Models;

public class RequestRefreshTokenModel
{
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Token { get; set; } = default!;
}
