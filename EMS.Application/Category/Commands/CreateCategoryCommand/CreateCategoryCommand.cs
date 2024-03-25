using EMS.Application.Common.Dto.Category;
using MediatR;

namespace EMS.Application.Category.Commands.CreateCategoryCommand;

public record CreateCategoryCommand(CreateCategoryDto Category) : IRequest<CategoryDetailsDto?>;