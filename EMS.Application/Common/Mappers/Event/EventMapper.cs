﻿using EMS.Application.Common.Dto.Event;
using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Mappers.Category;
using EMS.Application.Common.Mappers.Location;
using EMS.Application.Common.Mappers.Reservation;
using EMS.Application.Common.Mappers.User;
using EMS.Domain.Enums;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Event;

[Mapper]
public static partial class EventMapper
{
    public static Domain.Entities.Event ToEntity(this CreateEventDto dto)
    {
        return new Domain.Entities.Event(dto.Name, dto.Description, dto.StartTime, dto.EndTime, dto.IsFree, dto.Price, EventSizeEnum.FromValue(dto.EventSize));

    }
    
    
    public static EventDetailsDto ToDetailsDto(this Domain.Entities.Event entity)
    {
       
        
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        var eventInfo = new EventInfoDto(
            entity.Category?.ToDetailsDto() ?? throw new NullReferenceException("Category is null"),
            entity.Location?.ToDetailsDto() ?? throw new NullReferenceException("Location is null"),
            entity.Reservations?.Select(x => x.Reservation.ToReservationDetailsDto()).ToList() ?? []
        );

        return new EventDetailsDto(
            entity.Name,
            entity.Description,
            entity.StartTime,
            entity.EndTime,
            entity.IsFree,
            entity.Price,
            entity.Category.Name,
            entity.EventSize.SubEvents.Select(x => x.Name).ToList(),
            eventInfo
        );
    }


    public static partial List<EventDetailsDto> ToDetailsList(this List<Domain.Entities.Event> entities);


    public static void ToEntity(this Domain.Entities.Event entity, UpdateEventDto dto)
    {
        entity.UpdateEvent(dto.Name, dto.Description, dto.StartTime, dto.EndTime, dto.IsFree, dto.Price);
    }
}