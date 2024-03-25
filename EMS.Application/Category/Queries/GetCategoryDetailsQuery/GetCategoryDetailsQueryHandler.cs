using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Category.Queries.GetCategoryDetailsQuery;

public class GetCategoryDetailsQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto?>
{
    public async Task<CategoryDetailsDto?> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.Where(x => x.Id.ToString().Equals(request.CategoryId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Category not found");

        return category.ToDetailsDto();

    }
}