using Application.Abstractions.CustomExceptions.Abstractions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class WrongEmailException : CustomException
{
    public WrongEmailException(string message) : base(message, ExceptionType.Unauthorized)
    {
    }
}