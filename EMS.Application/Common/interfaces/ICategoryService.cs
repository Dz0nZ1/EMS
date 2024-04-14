using EMS.Application.Common.Dto.Category;

namespace EMS.Application.Common.interfaces;

public interface ICategoryService
{
    Task<CategoryDetailsDto?> CreateAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken);
}