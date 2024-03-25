using Microsoft.AspNetCore.Identity;

namespace EMS.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    #region Properties

    public IList<ApplicationUserRole> UserRoles { get; set; }

    #endregion
}