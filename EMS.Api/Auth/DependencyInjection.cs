using EMS.Api.Auth.Constants;
using EMS.Api.Auth.Options;
using EMS.Api.Auth.Schemes;

namespace Demo.Api.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddEmsAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddScheme<HeaderBasicAuthenticationSchemeOptions, HeaderBasicAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
                schemeOptions => configuration.GetSection("Auth:Header")
                    .Bind(schemeOptions));
        
        // services.AddAuthentication()
        //     .AddScheme<JwtAuthenticationSchemeOptions, JwtAuthenticationSchemeHandler>(AuthConstants.HeaderBasicAuthenticationScheme,
        //         schemeOptions => configuration.GetSection("Auth:Header")
        //             .Bind(schemeOptions));

        return services;
    }
}
