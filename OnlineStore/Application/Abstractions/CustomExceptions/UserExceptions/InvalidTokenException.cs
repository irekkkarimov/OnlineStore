using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidTokenException : UnauthorizedException
{
    public InvalidTokenException(string message) : base(message)
    {
    }
}