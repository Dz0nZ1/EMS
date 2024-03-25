using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;
using MediatR;

namespace EMS.Application.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler(IEmsDbContext dbContext) : IRequestHandler<CreateCategoryCommand, CategoryDetailsDto?>
{
    public async Task<CategoryDetailsDto?> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Category.ToEntity();
        await dbContext.Categories.AddAsync(category, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return category.ToDetailsDto();

    }
}