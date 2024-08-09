using System.ComponentModel.DataAnnotations;

namespace NWBC_Assignment05.Models;

public class RoleAssignmentModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required] public string Role { get; set; }
}