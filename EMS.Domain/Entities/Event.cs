using Ardalis.GuardClauses;
using EMS.Domain.Enums;

namespace EMS.Domain.Entities;

public class Event 
{
    #region Properties

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime StartTime { get; private set; } = DateTime.Today;
    public DateTime EndTime { get; private set; } = DateTime.Today;

    public bool IsFree { get; private set; } = false;
    
    public decimal Price { get; private set; }
    public Location? Location { get; private set; }
    public Category? Category { get; private set; }
    public IEnumerable<ReservationEvent>? Reservations { get; private set; }
    
    public EventSizeEnum EventSize { get; private set; }

    #endregion

    #region Constructors

    public Event(string name, string description, DateTime startTime, DateTime endTime, bool isFree, decimal price, EventSizeEnum eventSize)
    {
        Id = Guid.NewGuid();
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
        IsFree = isFree;
        Price = price;
        EventSize = Guard.Against.Null(eventSize);
    }
    
    private Event(){}

    #endregion

    #region Extensions

    public Event AddCategory(Category category)
    {
        Category = category;
        return this;
    }

    public Event AddLocation(Location location)
    {
        Location = location;
        return this;
    }


    public Event UpdateEvent(string name, string description, DateTime startDate, DateTime endDate, bool isFree,
        decimal price)
    {
        Name = name;
        Description = description;
        StartTime = startDate;
        EndTime = endDate;
        IsFree = isFree;
        Price = price;
        return this;
    }

    #endregion
}