using EMS.Domain.Entities;

namespace Ems.BaseTests.Builders.Domain;

public class LocationBuilder
{
    private string _name = "The Langham, New York, Fifth Avenue";
    private  string _country = "USA";
    private  string _city = "New York";
    private  string _address = "400 Fifth Avenue, New York, NY 10018, United States";
    
    public Location Build() => new(_name, _country, _city, _address);


    public LocationBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LocationBuilder WithCountry(string country)
    {
        _country = country;
        return this;
    }

    public LocationBuilder WithCity(string city)
    {
        _city = city;
        return this;
    }

    public LocationBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }
    
    
    
}