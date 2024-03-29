namespace EMS.Domain.Entities;

public class Reservation
{
   #region Properties

   public Guid Id { get; private set; }
   public DateTime ReservationDate { get; private set; } = DateTime.Today;
   
   public decimal Price { get; private set; }

   public bool hasCoupon { get; set; } = false;
   
   public string UserId { get; private set; }
   public ApplicationUser User { get; private set; }
   
   public IEnumerable<ReservationEvent>? Events { get; private set; }

   #endregion

   #region Constructors

   public Reservation(DateTime reservationDate, decimal price, bool hasCoupon)
   {
      Id = Guid.NewGuid();
      ReservationDate = reservationDate;
      Price = price;
      hasCoupon = hasCoupon;
   }
   
   private Reservation(){}

   #endregion

   #region Extesnions

   public Reservation AddUser(ApplicationUser user)
   {
      User = user;
      return this;
   }

   public Reservation AddCoupon(bool coupon)
   {
      hasCoupon = coupon;
      return this;
   }
   
   
   #endregion
    
}