using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.Products;

public class WrongProduct : CustomException
{
    public WrongProduct(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}