using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.PromoCode;

public class WrongPromoCodeException : NotFoundException
{
    public WrongPromoCodeException(string message) : base(message)
    {
    }
}