using System.Net;
using System.Net.Http.Json;
using EMS.Application.Common.Dto.Category;
using Ems.BaseTests.Builders.Domain;
using EMS.Infrastructure.Contexts;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.FunctionalTests.Category.Queries;

public class GetProductDetailsQueryTests : BaseTest
{
    

    [Fact]
    public async Task GetCategoryDetailsQueryTest_GivenValidCategoryId_StatusOk()
    {
        

        //Given
        var category = new CategoryBuilder().Build();

        await EmsDbContext.Categories.AddAsync(category);

        await EmsDbContext.SaveChangesAsync();
        
        //When

        var response = await Client.GetAsync($"api/v1/Category/GetCategoryDetails?CategoryId={category.Id.ToString()}");


        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadFromJsonAsync<CategoryDetailsDto>();

        content.Should().NotBeNull();
        content!.Name.Should().Be(category.Name);
        content!.Description.Should().Be(category.Description);
        
    }
    
    [Fact]
    public async Task GetCategoryDetailsQueryTest_GivenCategoryIdIsNull_BadRequest()
    {
        //Given
        
  
        //When

        var response = await Client.GetAsync($"api/v1/Category/GetCategoryDetails");


        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        
    }
    
    
    [Fact]
    public async Task GetCategoryDetailsQueryTest_GivenInvalidCategoryId_NotFound()
    {

        
        //Given
        var category = new CategoryBuilder().Build();

        await EmsDbContext.Categories.AddAsync(category);

        await EmsDbContext.SaveChangesAsync();
        
        //When

        var response = await Client.GetAsync($"api/v1/Category/GetCategoryDetails?CategoryId={Guid.NewGuid().ToString()}");


        //Then

        using var _ = new AssertionScope();

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        
        
    }

    public GetProductDetailsQueryTests(EmsWebApplicationFactory<Program> factory) : base(factory)
    {
    }
}