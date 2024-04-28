using EMS.Application.Common.Dto.Auth;
using MediatR;

namespace EMS.Application.Auth.Commands.CompleteLoginCommand;

public record CompleteLoginCommand(string ValidationToken) : IRequest<CompleteLoginResponseDto>;