using EMS.Application.Common.Dto.Location;
using MediatR;

namespace EMS.Application.Location.Commands.UpdateLocationCommand;

public record UpdateLocationCommand(UpdateLocationDto Location) : IRequest<LocationDetailsDto?>;