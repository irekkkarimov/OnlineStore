using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidUsernameException : CustomException
{
    public InvalidUsernameException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}