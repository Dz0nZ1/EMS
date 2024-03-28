using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using EMS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Reservation.Commands;

public class CreateReservationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<CreateReservationCommand, ReservationDetailsDto?>
{
    public async Task<ReservationDetailsDto?> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Reservation.UserId, cancellationToken)
                   ?? throw new NotFoundException("User not found");

        var reservation = request.Reservation.ToEntity().AddUser(user);
        
        await dbContext.Reservations.AddAsync(reservation, cancellationToken);
        
        foreach (var eventId in request.Reservation.EventIds)
        {
            var eventEntity = await dbContext.Events.FirstOrDefaultAsync(x => x.Id == eventId, cancellationToken)
                              ?? throw new NotFoundException($"Event with ID {eventId} not found");

            var reservationEvent = new ReservationEvent();
            reservationEvent.AddReservationEvent(eventEntity, reservation);

            await dbContext.ReservationEvents.AddAsync(reservationEvent, cancellationToken);
        }
        
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return reservation.ToReservationDetailsDto();

    }
}