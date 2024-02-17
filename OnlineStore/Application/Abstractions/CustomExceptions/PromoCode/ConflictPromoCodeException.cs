using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.PromoCode;

public class ConflictPromoCodeException : ConflictException
{
    public ConflictPromoCodeException(string message) : base(message)
    {
    }
}