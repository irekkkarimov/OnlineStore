using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class WrongPasswordException : CustomException
{
    public WrongPasswordException(string message) : base(message, ExceptionType.Unauthorized)
    {
    }
}