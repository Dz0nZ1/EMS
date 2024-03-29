namespace EMS.Application.Common.Dto.Event;

public record UpdateEventDto(string EventId, string Name, string Description, DateTime StartTime, DateTime EndTime, bool IsFree, decimal Price);