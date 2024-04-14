using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using EMS.Application.Common.Dto.Event;
using EMS.Application.Event.Commands.CreateEventCommand;
using Ems.BaseTests.Builders.Commands;
using Ems.BaseTests.Builders.Domain;
using Ems.BaseTests.Builders.Dto;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.OpenApi.Extensions;
using Moq;

namespace EMS.FunctionalTests.Event.Commands;

public class CreateEventCommandTests : BaseTest

{

    public static readonly JsonSerializerOptions DefaultOptions = new();

    public static readonly JsonSerializerOptions SettingsWebOptions =
        new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    
    
    [Fact]
    public async Task CreateEventCommandTest_GivenValidCreateEventDto_ReturnsStatusOk()
    {
        
        //Given        
        
        var category = new CategoryBuilder().Build();
        var location = new LocationBuilder().Build();

        await EmsDbContext.Categories.AddAsync(category);
        await EmsDbContext.Locations.AddAsync(location);
        await EmsDbContext.SaveChangesAsync();
        

        var eventDto = new CreateEventDtoBuilder().WithCategoryId(category.Id.ToString())
            .WithLocationId(location.Id.ToString()).Build();

        // Setting the return value of mock services
        // MockCategoryService.Setup(x => x.CreateAsync()).Returns("Category");
        // MockLocationService.Setup(x => x.CreateAsync()).Returns("Location");
        
        //If location does not exist
        // MockLocationService.Setup(x => x.CreateAsync()).Throws(new NotFoundException());
        
        var @event = new CreateEventCommandBuilder().WithCreateEventDto(eventDto).Build();

        var jsonEvent = JsonSerializer.Serialize(@event);
        var contentRequest = new StringContent(jsonEvent, Encoding.UTF8, "application/json");

        
        //When
        var response = await Client.PostAsync($"api/v1/Event/CreateEvent", contentRequest, new CancellationToken());
        
        
        //Then
        using var _ = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<EventDetailsDto>();

        content.Should().NotBeNull();
        
        //Verifing if the service performed once
        // MockCategoryService.Verify(x => x.CreateAsync(), Times.Once);
    }

    public CreateEventCommandTests(EmsWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}