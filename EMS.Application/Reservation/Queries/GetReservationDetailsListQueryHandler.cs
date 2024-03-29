using EMS.Application.Common.Dto.Reservation;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Reservation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Reservation.Queries;

public class GetReservationDetailsListQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetReservationDetailsListQuery, List<ReservationDetailsDto>>
{
    public async Task<List<ReservationDetailsDto>> Handle(GetReservationDetailsListQuery request, CancellationToken cancellationToken)
    {
        var reservations = await dbContext.Reservations.Include(x => x.User).ToListAsync(cancellationToken);
        return reservations.ToListDto();
    }
}