using EMS.Domain.Enums;

namespace EMS.Application.Common.Dto.Event;

public record CreateEventDto(string Name, string Description, DateTime StartTime, DateTime EndTime, bool IsFree, decimal Price, string LocationId, string  CategoryId, int EventSize);