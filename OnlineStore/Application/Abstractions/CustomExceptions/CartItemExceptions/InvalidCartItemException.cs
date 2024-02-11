using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.CartItemExceptions;

public class InvalidCartItemException : CustomException
{
    public InvalidCartItemException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}