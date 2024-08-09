using System.ComponentModel.DataAnnotations;

namespace Common.Infraestructure.Models;

public class LoginModel
{
    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
}
