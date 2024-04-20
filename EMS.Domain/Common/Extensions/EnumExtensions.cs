using EMS.Domain.Enums;

namespace EMS.Domain.Common.Extensions;

public static class EnumExtensions
{
    public static readonly string CategoryValidList =
        string.Join(",", EventSizeEnum.List.Select(x => x.Name + "-" + x.Value));
}