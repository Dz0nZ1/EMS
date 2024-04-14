using EMS.Application.Common.Dto.Event;
using EMS.Application.Event.Commands.CreateEventCommand;
using Ems.BaseTests.Builders.Dto;

namespace Ems.BaseTests.Builders.Commands;

public class CreateEventCommandBuilder
{

    private CreateEventDto _createEventDto = new CreateEventDtoBuilder().Build();
    
    public CreateEventCommand Build() => new(_createEventDto);


    public CreateEventCommandBuilder WithCreateEventDto(CreateEventDto eventDto)
    {
        _createEventDto = eventDto;
        return this;
    }
    
}


