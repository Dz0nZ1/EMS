using EMS.Domain.Entities;

namespace Ems.BaseTests.Builders.Domain;

public class CategoryBuilder
{

    private string _name = "Programming";

    private string _description = "All topics related to Programming";

    public Category Build() => new(_name, _description);


    public CategoryBuilder WithName(string name)
    {
        _name = name;
        return this;
    }


    public CategoryBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }
    
}