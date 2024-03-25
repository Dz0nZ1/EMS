using EMS.Application.Common.Dto.Location;
using MediatR;

namespace EMS.Application.Location.Commands.CreateLocationCommand;

public record CreateLocationCommand(CreateLocationDto Location) : IRequest<LocationDetailsDto?>;