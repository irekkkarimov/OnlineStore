using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidEmailException : BadRequestException
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}