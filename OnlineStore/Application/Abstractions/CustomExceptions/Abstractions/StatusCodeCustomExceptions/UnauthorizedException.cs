namespace Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message) : base(message, ExceptionType.Unauthorized)
    {
    }
}