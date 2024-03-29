using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Reservation.Commands.DeleteReservationCommand;

public class DeleteReservationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<DeleteReservationCommand, string?>
{
    public async Task<string?> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await dbContext.Reservations.Where(x => x.Id.ToString().Equals(request.ReservationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Reservation not found");
        dbContext.Reservations.Remove(reservation);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return "Reservation deleted successfully";
    }
}