using EMS.Application.Common.Dto.Auth;
using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.Auth.Commands.CompleteLoginCommand;

public class CompleteLoginCommandHandler(IAuthService authService) : IRequestHandler<CompleteLoginCommand, CompleteLoginResponseDto>
{
    public async Task<CompleteLoginResponseDto> Handle(CompleteLoginCommand request, CancellationToken cancellationToken)
    {
        return await authService.CompleteLoginAsync(request.ValidationToken);
    }
}