using System.Net;
using System.Net.Http.Json;
using EMS.Application.Common.Dto.Location;
using Ems.BaseTests.Builders.Domain;
using FluentAssertions;
using FluentAssertions.Execution;

namespace EMS.FunctionalTests.Location;

public class GetLocationDetailsQueryTests : BaseTest
{
    protected GetLocationDetailsQueryTests(EmsWebApplicationFactory<Program> factory) : base(factory)
    {
        
    }

    [Fact]
    public async Task GetLocationDetailsQueryTest_GivenValidLocationId_StatusOk()
    {
        
        
        //Given

        var location = new LocationBuilder().Build();

        await EmsDbContext.Locations.AddAsync(location);

        await EmsDbContext.SaveChangesAsync();
        
        //When

        var response = await Client.GetAsync($"api/v1/Location/GetLocationDetails?LocationId={location.Id.ToString()}");

        
        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<LocationDetailsDto>();

        content.Should().NotBeNull();
        content!.Name.Should().Be(location.Name);
        content!.Address.Should().Be(location.Address);
        content.City.Should().Be(location.City);
        content.Country.Should().Be(location.Country);
        
    }


    [Fact]
    public async Task GetLocationDetailsQueryTest_GivenLocationIdIsNull_BadRequest()
    {
        //Given

        var response = await Client.GetAsync($"api/v1/Location/GetLocationDetails");
        
        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);


    }
    
    
    
}