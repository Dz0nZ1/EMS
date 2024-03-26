namespace EMS.Application.Common.Dto.Event;

public record EventDetailsDto(string Name, string Description, DateTime StartTime, DateTime EndTime, bool IsFree, decimal Price, string CategoryName, string CategoryDescription, string LocationName, string LocationCountry, string LocationCity, string LocationAddress);