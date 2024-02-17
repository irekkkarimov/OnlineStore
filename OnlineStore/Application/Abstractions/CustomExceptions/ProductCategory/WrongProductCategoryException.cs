using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.ProductCategory;

public class WrongProductCategoryException : BadRequestException
{
    public WrongProductCategoryException(string message) : base(message)
    {
    }
}