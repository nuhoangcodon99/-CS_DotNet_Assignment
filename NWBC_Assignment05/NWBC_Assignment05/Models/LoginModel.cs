using System.ComponentModel.DataAnnotations;

namespace NWBC_Assignment05.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}