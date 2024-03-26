namespace EMS.Domain.Entities;

public class Reservation
{
   #region Properties

   public Guid Id { get; private set; }
   public DateTime ReservationDate { get; private set; } = DateTime.Today;
   
   public decimal Price { get; private set; }

   public bool hasCupon { get; set; } = false;
   
   public Guid EventId { get; private set; }
   public Event? Event { get; private set; }

   public string UserId { get; private set; }
   public ApplicationUser? User { get; private set; }

   #endregion

   #region Constructors

   public Reservation(DateTime reservationDate, decimal price, bool hasCupon)
   {
      Id = Guid.NewGuid();
      ReservationDate = reservationDate;
      Price = price;
      hasCupon = hasCupon;
   }
   
   private Reservation(){}

   #endregion

   #region Extesnions

   public Reservation AddUser(ApplicationUser user)
   {
      User = user;
      return this;
   }

   public Reservation AddEvent(Event eventEntity)
   {
      Event = eventEntity;
      return this;
   }
   
   #endregion
    
}