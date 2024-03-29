using MediatR;

namespace EMS.Application.Location.Commands.DeleteLocationCommand;

public record DeleteLocationCommand(string LocationId) : IRequest<string?>;