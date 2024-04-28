using EMS.Application.Common.Dto.Auth;
using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.Auth.Commands.BeginLoginCommand;

public class BeginLoginCommandHandler(IAuthService authService) : IRequestHandler<BeginLoginCommand, BeginLoginResponseDto>
{
    public async Task<BeginLoginResponseDto> Handle(BeginLoginCommand request, CancellationToken cancellationToken)
    {
       return await authService.BeginLoginAsync(request.EmailAddress);
    }
}