using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidUsernameException : BadRequestException
{
    public InvalidUsernameException(string message) : base(message)
    {
    }
}