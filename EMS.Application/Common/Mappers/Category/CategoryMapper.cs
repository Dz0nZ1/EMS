using EMS.Application.Common.Dto.Category;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Category;

[Mapper]
public static partial class CategoryMapper
{
    public static partial Domain.Entities.Category ToEntity(this CreateCategoryDto dto);
    
    public static partial CategoryDetailsDto ToDetailsDto(this Domain.Entities.Category entity);

    public static partial List<CategoryDetailsDto> ToDetailsList(this List<Domain.Entities.Category> entities);

    public static void ToEntity(this Domain.Entities.Category category, UpdateCategoryDto dto)
    {
        category.UpdateCategory(dto.Name, dto.Description);
    }

}