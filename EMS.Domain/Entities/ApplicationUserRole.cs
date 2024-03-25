using Microsoft.AspNetCore.Identity;

namespace EMS.Domain.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    #region Properties

    public ApplicationUser User { get; set; }
    
    public ApplicationRole Role { get; set; }

    #endregion
}