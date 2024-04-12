using EMS.Domain.Entities;

namespace Ems.BaseTests.Builders.Domain;

public class ReservationBuilder
{
    private DateTime _reservationDate = DateTime.Today;
    private decimal _price = 100.0m;
    private bool _hasCoupon = false;
    private string _userId = string.Empty;
    private ApplicationUser? _user;
    private IEnumerable<ReservationEvent>? _events;

    public ReservationBuilder WithReservationDate(DateTime reservationDate)
    {
        _reservationDate = reservationDate;
        return this;
    }

    public ReservationBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ReservationBuilder WithHasCoupon(bool hasCoupon)
    {
        _hasCoupon = hasCoupon;
        return this;
    }

    public ReservationBuilder WithUser(ApplicationUser user)
    {
        _user = user;
        _userId = user?.Id;
        return this;
    }

    public ReservationBuilder WithEvents(IEnumerable<ReservationEvent> events)
    {
        _events = events;
        return this;
    }

    public Reservation Build()
    {
        var reservation = new Reservation(_reservationDate, _price, _hasCoupon);
            
        // Set the user and events
        if (_user != null)
        {
            reservation.AddUser(_user);
        }
            
        // You can add more complex setup if required

        return reservation;
    }
}