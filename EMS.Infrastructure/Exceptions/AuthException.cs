using EMS.Application.Common.Exceptions;

namespace EMS.Infrastructure.Exceptions;

public class AuthException(string message, object? additionalData = null) : BaseException(message, additionalData){}