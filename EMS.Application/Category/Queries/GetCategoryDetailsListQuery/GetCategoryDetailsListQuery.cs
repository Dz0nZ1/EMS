using EMS.Application.Common.Dto.Category;
using MediatR;

namespace EMS.Application.Category.Queries.GetCategoryDetailsListQuery;

public record GetCategoryDetailsListQuery() : IRequest<List<CategoryDetailsDto>>;