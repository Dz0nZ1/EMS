using EMS.Application.Common.Dto.Category;
using MediatR;

namespace EMS.Application.Category.Commands.UpdateCategoryCommand;

public record UpdateCategoryCommand(UpdateCategoryDto Category) : IRequest<CategoryDetailsDto?>;