using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.Products;

public class ForbiddenProductAccessException : ForbiddenException
{
    public ForbiddenProductAccessException(string message) : base(message)
    {
    }
}