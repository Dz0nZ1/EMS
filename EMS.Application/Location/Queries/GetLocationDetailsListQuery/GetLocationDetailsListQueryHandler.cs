using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Location;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Location.Queries.GetLocationDetailsListQuery;

public class GetLocationDetailsListQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetLocationDetailsListQuery, List<LocationDetailsDto>>
{
    public async Task<List<LocationDetailsDto>> Handle(GetLocationDetailsListQuery request, CancellationToken cancellationToken)
    {
        var locations =  await dbContext.Locations.ToListAsync(cancellationToken: cancellationToken);
        return locations.ToDetailsList();
    }
}