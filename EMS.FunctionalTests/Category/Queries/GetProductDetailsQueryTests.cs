using System.Net;
using System.Net.Http.Json;
using EMS.Application.Common.Dto.Category;
using EMS.Infrastructure.Contexts;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.FunctionalTests.Category.Queries;

public class GetProductDetailsQueryTests(EmsWebApplicationFactory<Program> factory)
    : IClassFixture<EmsWebApplicationFactory<Program>>
{
    
    private readonly HttpClient _client = factory.CreateClient();


    [Fact]
    public async Task GetCategoryDetailsQueryTest_GivenValidCategoryId_StatusOk()
    {

        using var scope = factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EmsDbContext>();
        

        //Given
        var category = new Domain.Entities.Category("Programming", "All topics related to Programming");

        await dbContext.Categories.AddAsync(category);

        await dbContext.SaveChangesAsync();
        
        //When

        var response = await _client.GetAsync($"api/v1/Category/GetCategoryDetails?CategoryId={category.Id.ToString()}");


        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<CategoryDetailsDto>();

        content.Should().NotBeNull();
        content!.Name.Should().Be(category.Name);
        content!.Description.Should().Be(category.Description);
        
    }
    
}