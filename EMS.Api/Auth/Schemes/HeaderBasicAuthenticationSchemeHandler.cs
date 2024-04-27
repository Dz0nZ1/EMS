using System.Security.Claims;
using System.Text.Encodings.Web;
using EMS.Api.Auth.Options;
using EMS.Application.Common.Extensions;
using EMS.Application.Common.interfaces;
using EMS.Application.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace EMS.Api.Auth.Schemes;

public class HeaderBasicAuthenticationSchemeHandler : AuthenticationHandler<HeaderBasicAuthenticationSchemeOptions>
{
    private readonly IEmsDbContext _dbContext;
    private readonly AesEncryptionConfiguration _aesEncryptionConfiguration;
    
    [Obsolete("Obsolete")]
    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IEmsDbContext dbContext, IOptions<AesEncryptionConfiguration> aesEncryptionConfiguration) : base(options,
        logger,
        encoder,
        clock)
    {
        _dbContext = dbContext;
        _aesEncryptionConfiguration = aesEncryptionConfiguration.Value;
    }

    public HeaderBasicAuthenticationSchemeHandler(IOptionsMonitor<HeaderBasicAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, IEmsDbContext dbContext, IOptions<AesEncryptionConfiguration> aesEncryptionConfiguration) : base(options,
        logger,
        encoder)
    {
        _dbContext = dbContext;
        _aesEncryptionConfiguration = aesEncryptionConfiguration.Value;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            var username = Request.Headers[Options.UsernameHeader]
                    .FirstOrDefault() ??
                throw new InvalidOperationException("Missing Username header");
            var password = Request.Headers[Options.PasswordHeader]
                    .FirstOrDefault() ??
                throw new InvalidOperationException("Missing Username header");

            var user = Options.Users.SingleOrDefault(user => user.Username.Equals(username,
                        StringComparison.OrdinalIgnoreCase) &&
                    user.Password.Decrypt(_aesEncryptionConfiguration.Key).Equals(password,
                        StringComparison.OrdinalIgnoreCase)) ??
                throw new InvalidOperationException("User not found");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,
                    username)
            };
            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role,
                role)));
            claims.AddRange(user.Claims.Select(x => new Claim(x.Key,
                x.Value)));

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims,
                "Tokens"));
            var ticket = new AuthenticationTicket(principal,
                Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        catch (Exception e)
        {
            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
