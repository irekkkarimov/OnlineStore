using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.Products;

public class WrongProduct : NotFoundException
{
    public WrongProduct(string message) : base(message)
    {
    }
}