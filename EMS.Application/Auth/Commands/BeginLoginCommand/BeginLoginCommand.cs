using EMS.Application.Common.Dto.Auth;
using MediatR;

namespace EMS.Application.Auth.Commands.BeginLoginCommand;

public record BeginLoginCommand(string EmailAddress) : IRequest<BeginLoginResponseDto>;
