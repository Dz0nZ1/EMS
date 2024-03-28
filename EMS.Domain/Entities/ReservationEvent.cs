namespace EMS.Domain.Entities;

public class ReservationEvent
{
    #region Properties

    public Guid Id { get; private set; }
    public Guid EventId { get; private set; }
    public Event Event { get; private set; }
    public Guid ReservationId { get; private set; }
    public Reservation Reservation { get; private set; }
    
    #endregion


    #region Constructors

    public ReservationEvent()
    {
        Id = Guid.NewGuid();
    }
    

    #endregion

    #region Extensions

    public ReservationEvent AddReservationEvent(Event @event, Reservation reservation)
    {
        Event = @event;
        Reservation = reservation;
        return this;
    }

    #endregion
}