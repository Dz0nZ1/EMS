using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Category.Queries.GetCategoryDetailsListQuery;

public class GetCategoryDetailsListQueryHandler(IEmsDbContext dbContext) : IRequestHandler<GetCategoryDetailsListQuery, List<CategoryDetailsDto>>
{
    public async Task<List<CategoryDetailsDto>> Handle(GetCategoryDetailsListQuery request, CancellationToken cancellationToken)
    {
        var categories = await dbContext.Categories.ToListAsync(cancellationToken: cancellationToken);
        return categories.ToDetailsList();
    }
}