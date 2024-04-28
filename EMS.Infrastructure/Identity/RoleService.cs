using EMS.Application.Common.interfaces;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace EMS.Infrastructure.Identity;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{
    public async Task CreateRoleAsync(string role)
    {
        var roleAlreadyExists = await roleManager.RoleExistsAsync(role);

        if (!roleAlreadyExists)
        {
            await roleManager.CreateAsync(new ApplicationRole()
            {
                Name = role,
                NormalizedName = role.Normalize()
            });
        }
        
    }
}