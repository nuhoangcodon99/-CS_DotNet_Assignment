using Microsoft.AspNetCore.Identity;

namespace NWBC_Assignment05.Entities;

public class ApplicationUser : IdentityUser
{
    public Guid Id {
        get;
        set;
    }
    public string UserName  { get; set; }
    
}