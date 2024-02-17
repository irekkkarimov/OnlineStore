using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.CartItemExceptions;

public class InvalidCartItemException : BadRequestException
{
    public InvalidCartItemException(string message) : base(message)
    {
    }
}