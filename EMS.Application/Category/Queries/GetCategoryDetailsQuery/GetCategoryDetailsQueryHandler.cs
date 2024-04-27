using EMS.Application.Common.Dto.Category;
using EMS.Application.Common.Exceptions;
using EMS.Application.Common.Extensions;
using EMS.Application.Common.interfaces;
using EMS.Application.Common.Mappers.Category;
using EMS.Application.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EMS.Application.Category.Queries.GetCategoryDetailsQuery;

public class GetCategoryDetailsQueryHandler(IEmsDbContext dbContext, IOptions<AesEncryptionConfiguration> aesConfiguration) : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto?>
{
    public async Task<CategoryDetailsDto?> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await dbContext.Categories.Where(x => x.Id.ToString().Equals(request.CategoryId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Category not found");

        var testPassword = "Nikola123";
        var testPassEncrypt = testPassword.Encrypt(aesConfiguration.Value.Key);
        var testPassDecrypt = testPassEncrypt.Decrypt(aesConfiguration.Value.Key);
        

        return category.ToDetailsDto();

    }
}