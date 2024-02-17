using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.Products;

public class InvalidProductException : BadRequestException
{
    public InvalidProductException(string message) : base(message)
    {
    }
}