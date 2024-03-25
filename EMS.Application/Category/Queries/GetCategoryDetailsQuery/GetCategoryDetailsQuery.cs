using EMS.Application.Common.Dto.Category;
using MediatR;

namespace EMS.Application.Category.Queries.GetCategoryDetailsQuery;

public record GetCategoryDetailsQuery(string CategoryId) : IRequest<CategoryDetailsDto?>;