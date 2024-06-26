using Microsoft.AspNetCore.Identity;

namespace EMS.Domain.Entities;

public class ApplicationUser : IdentityUser
{
   #region Properties

   public string FirstName { get; set; } = string.Empty;

   public string LastName { get; set; } = string.Empty;

   public IList<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
   
   public IList<Reservation> Reservations { get; private set; }

   #endregion

}