using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidPasswordException : CustomException
{
    public InvalidPasswordException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}