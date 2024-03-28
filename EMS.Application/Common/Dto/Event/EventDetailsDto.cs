using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Dto.Users;
using EMS.Domain.Entities;

namespace EMS.Application.Common.Dto.Event;

public record EventDetailsDto(
    string Name,
    string Description,
    DateTime StartTime,
    DateTime EndTime,
    bool IsFree,
    decimal Price, EventInfoDto EventInfoDto)

{
    
    internal EventDetailsDto AddEventInfo(EventInfoDto eventInfoDto)
    {
        return this with { EventInfoDto = eventInfoDto };
    }
    
    
}