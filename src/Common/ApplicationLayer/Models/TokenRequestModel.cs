using System.ComponentModel.DataAnnotations;

namespace Common.Infraestructure.Models;

public class TokenRequestModel
{
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;

    public string? VerificationCode { get; set; }
}
