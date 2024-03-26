using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Reservation.Commands;

public class CreateReservationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<CreateReservationCommand, ReservationDetailsDto?>
{
    public async Task<ReservationDetailsDto?> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.Where(x => x.Id.Equals(request.Reservation.UserId))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("User not found");
        
        var eventEntity = await dbContext.Events.Where(x => x.Id.Equals(request.Reservation.EventId))
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("Event not found");

        var reservation = request.Reservation.ToEntity().AddUser(user).AddEvent(eventEntity);

        await dbContext.Reservations.AddAsync(reservation, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

        return reservation.ToDetailsDto();

    }
}