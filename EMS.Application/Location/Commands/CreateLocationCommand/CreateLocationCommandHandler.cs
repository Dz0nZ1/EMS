using EMS.Application.Common.Dto.Location;
using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.Location.Commands.CreateLocationCommand;

public class CreateLocationCommandHandler(ILocationService locationService) : IRequestHandler<CreateLocationCommand, LocationDetailsDto?>
{
    public async Task<LocationDetailsDto?> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        return await locationService.CreateAsync(request.Location, cancellationToken: cancellationToken);
    }
}