using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Infrastructure.Services;

public class ReservationService(IEmsDbContext dbContext) : IReservationService
{
    public async Task<ReservationDetailsDto?> CreateAsync(CreateReservationDto reservationDto, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == reservationDto.UserId, cancellationToken)
                   ?? throw new NotFoundException("User not found");

        var reservation = reservationDto.ToEntity().AddUser(user);
        
        await dbContext.Reservations.AddAsync(reservation, cancellationToken);
        
        foreach (var eventId in reservationDto.EventIds)
        {
            var eventEntity = await dbContext.Events.FirstOrDefaultAsync(x => x.Id.ToString() == eventId, cancellationToken)
                              ?? throw new NotFoundException($"Event with ID {eventId} not found");

            var reservationEvent = new ReservationEvent();
            reservationEvent.AddReservationEvent(eventEntity, reservation);

            await dbContext.ReservationEvents.AddAsync(reservationEvent, cancellationToken);
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return reservation.ToReservationDetailsDto();
    }
}