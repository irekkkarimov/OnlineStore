using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.Products;

public class InvalidProductException : CustomException
{
    public InvalidProductException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}