using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.interfaces;
using MediatR;

namespace EMS.Application.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler(ICategoryService categoryService) : IRequestHandler<CreateCategoryCommand, CategoryDetailsDto?>
{
    public async Task<CategoryDetailsDto?> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryService.CreateAsync(request.Category, cancellationToken: cancellationToken);
    }
}