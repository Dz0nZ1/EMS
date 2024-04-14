using EMS.Application.Common.Dto.Event;

namespace EMS.Application.Common.interfaces;

public interface IEventService
{
   Task<EventDetailsDto?> CreateAsync(CreateEventDto eventDto, CancellationToken cancellationToken);
}