using MediatR;

namespace EMS.Application.Category.Commands.DeleteCategoryCommand;

public record DeleteCategoryCommand(string CategoryId) : IRequest<string?>;