using EMS.Application.Category.Commands.CreateCategoryCommand;
using EMS.Application.Category.Queries.GetCategoryDetailsQuery;
using EMS.Application.Common.Dto.Category;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controller;

public class CategoryController : ApiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<CategoryDetailsDto>> GetCategoryDetails([FromQuery] GetCategoryDetailsQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost]
    public async Task<ActionResult<CategoryDetailsDto>> CreateCategory(CreateCategoryCommand command) =>
        Ok(await Mediator.Send(command));
}