namespace EMS.Domain.Entities;

public class EventApplicationUser
{
    #region Properties

    public Guid Id { get; private set; }
    public string UserId { get; private set; }
    public ApplicationUser? User { get; private set; }
    public Guid EventId { get; private set; }
    public Event? Event { get; private set; }
    
    #endregion


    #region Constructors

    public EventApplicationUser()
    {
        Id = Guid.NewGuid();
    }
    

    #endregion
}