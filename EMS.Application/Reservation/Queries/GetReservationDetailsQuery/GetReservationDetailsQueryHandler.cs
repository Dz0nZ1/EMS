using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Reservation.Queries.GetReservationDetailsQuery;

public class GetReservationDetailsQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetReservationDetailsQuery, ReservationDetailsDto?>
{
    public async Task<ReservationDetailsDto?> Handle(GetReservationDetailsQuery request, CancellationToken cancellationToken)
    {
        var reservation = await dbContext.Reservations.Where(x => x.Id.ToString().Equals(request.ReservationId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Reservation not found");
        return reservation.ToReservationDetailsDto();
    }
}