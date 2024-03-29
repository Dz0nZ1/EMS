namespace EMS.Domain.Entities;

public class Location
{
    #region Properties

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    
    public IList<Event>? Events = new List<Event>();
    
    #endregion


    #region Constructors

    public Location(string name, string country, string city, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        Country = country;
        City = city;
        Address = address;
    }
    
    private Location(){}

    #endregion

    #region Extensions

    public Location UpdateLocation(string name, string country, string city, string address)
    {
        Name = name;
        Country = country;
        City = city;
        Address = address;
        return this;
    }

    #endregion
}