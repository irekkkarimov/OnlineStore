using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class InvalidEmailException : CustomException
{
    public InvalidEmailException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}