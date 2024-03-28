using EMS.Application.Common.Dto.Users;
using EMS.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace EMS.Application.Common.Mappers.User;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDetailsDto ToDetailsDto(this ApplicationUser entity);
}