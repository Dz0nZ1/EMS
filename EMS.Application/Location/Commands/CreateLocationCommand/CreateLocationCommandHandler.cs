using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Location;
using MediatR;

namespace EMS.Application.Location.Commands.CreateLocationCommand;

public class CreateLocationCommandHandler(IEmsDbContext dbContext) : IRequestHandler<CreateLocationCommand, LocationDetailsDto?>
{
    public async Task<LocationDetailsDto?> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = request.Location.ToEntity();
        await dbContext.Locations.AddAsync(location, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return location.ToDetailsDto();
    }
}