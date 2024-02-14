using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.PromoCode;

public class InvalidPromoCodeException : BadRequestException
{
    public InvalidPromoCodeException(string message) : base(message)
    {
    }
}