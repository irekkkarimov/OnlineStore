using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidPasswordException : BadRequestException
{
    public InvalidPasswordException(string message) : base(message)
    {
    }
}