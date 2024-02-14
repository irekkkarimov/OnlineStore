using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.Abstractions.Purchase;

public class InvalidPurchaseException : BadRequestException
{
    public InvalidPurchaseException(string message) : base(message)
    {
    }
}