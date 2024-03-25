namespace EMS.Domain.Entities;

public class Reservation
{
   #region Properties

   public Guid Id { get; private set; }
   public DateTime ReservationDate { get; private set; } = DateTime.Today;
   public Guid EventId { get; private set; }
   public Event? Event { get; private set; }

   public string UserId { get; private set; }
   public ApplicationUser? User { get; private set; }

   #endregion

   #region Constructors

   public Reservation(DateTime reservationDate)
   {
      Id = Guid.NewGuid();
      ReservationDate = reservationDate;
   }
   
   private Reservation(){}

   #endregion
    
}