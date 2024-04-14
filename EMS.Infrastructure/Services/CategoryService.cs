using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;

namespace EMS.Infrastructure.Services;

public class CategoryService(IEmsDbContext dbContext) : ICategoryService
{
    public async Task<CategoryDetailsDto?> CreateAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken)
    {
        var category = categoryDto.ToEntity();
        await dbContext.Categories.AddAsync(category, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return category.ToDetailsDto();
    }
}