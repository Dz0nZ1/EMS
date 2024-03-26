using EMS.Application.Common.Exceptions;
using EMS.Application.Common.interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Category.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommandHandler(IEmsDbContext dbContext) : IRequestHandler<DeleteCategoryCommand, string?>
{
    public async Task<string?> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {

        var category = await dbContext.Categories.Where(x => x.Id.ToString().Equals(request.CategoryId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Category not found");

        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return "Deleted successfully";
    }
}