using EMS.Application.Common.Dto.Category;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.Category;

[Mapper]
public static partial class CategoryMapper
{
    public static partial Domain.Entities.Category ToEntity(this CreateCategoryDto dto);
    
    public static partial CategoryDetailsDto ToDetailsDto(this Domain.Entities.Category entity);
    
}