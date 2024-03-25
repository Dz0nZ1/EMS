namespace EMS.Domain.Entities;

public class Event 
{
    #region Properties

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime StartTime { get; private set; } = DateTime.Today;
    public DateTime EndTime { get; private set; } = DateTime.Today;
    public Location? Location { get; private set; }
    public Category? Category { get; private set; }

    public IList<Reservation> Reservations { get; private set; }
    
    public IList<EventApplicationUser>? Users = new List<EventApplicationUser>();

    #endregion

    #region Constructors

    public Event(string name, string description, DateTime startTime, DateTime endTime)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
    }
    
    private Event(){}

    #endregion
}