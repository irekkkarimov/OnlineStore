using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.ProductCategory;

public class WrongProductCategoryException : CustomException
{
    public WrongProductCategoryException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}