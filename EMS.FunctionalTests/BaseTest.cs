using EMS.Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.FunctionalTests;

public class BaseTest : IClassFixture<EmsWebApplicationFactory<Program>>
{
    private readonly EmsWebApplicationFactory<Program> _factory;
    protected readonly HttpClient  Client;
    protected readonly EmsDbContext EmsDbContext;

    protected BaseTest(EmsWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        Client = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        EmsDbContext = scope.ServiceProvider.GetRequiredService<EmsDbContext>();
    }
}