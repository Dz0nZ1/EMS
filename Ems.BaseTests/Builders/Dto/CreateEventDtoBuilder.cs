using EMS.Application.Common.Dto.Event;

namespace Ems.BaseTests.Builders.Dto;

public class CreateEventDtoBuilder
{
    private string _name = "Default Name";
    private string _description = "Default Description";
    private DateTime _startTime = DateTime.Now.AddHours(1);
    private DateTime _endTime = DateTime.Now.AddDays(1);
    private bool _isFree = true;
    private decimal _price = 5000;
    private string _locationId = "Default Location";
    private string _categoryId = "Default Category";
    
    
    public CreateEventDto Build() => new (_name, _description, _startTime, _endTime, _isFree, _price, _locationId, _categoryId);

    public CreateEventDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CreateEventDtoBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public CreateEventDtoBuilder WithStartTime(DateTime startTime)
    {
        _startTime = startTime;
        return this;
    }

    public CreateEventDtoBuilder WithEndTime(DateTime endTime)
    {
        _endTime = endTime;
        return this;
    }

    public CreateEventDtoBuilder WithIsFree(bool isFree)
    {
        _isFree = isFree;
        return this;
    }

    public CreateEventDtoBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public CreateEventDtoBuilder WithLocationId(string locationId)
    {
        _locationId = locationId;
        return this;
    }

    public CreateEventDtoBuilder WithCategoryId(string categoryId)
    {
        _categoryId = categoryId;
        return this;
    }
    

}