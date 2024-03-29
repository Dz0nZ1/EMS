using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Category.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommandHandler(IEmsDbContext dbContext) : IRequestHandler<UpdateCategoryCommand, CategoryDetailsDto?>
{
    public async Task<CategoryDetailsDto?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =
            await dbContext.Categories.Where(x => x.Id.ToString().Equals(request.Category.CategoryId))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException("Category not found");
        category.ToEntity(request.Category);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return category.ToDetailsDto();
    }
}