using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EMS.Application.Reservation.Commands.UpdateReservationCommand;

public class UpdateReservationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<UpdateReservationCommand, ReservationDetailsDto?>
{
    public async Task<ReservationDetailsDto?> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation =
            await dbContext.Reservations.Where(x => x.Id.ToString().Equals(request.Reservation.ReservationId))
                .Include(x => x.User)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Reservation not found");
        reservation.ToEntity(request.Reservation);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return reservation.ToReservationDetailsDto();
    }
}