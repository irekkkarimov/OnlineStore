namespace Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message) : base(message, ExceptionType.Forbidden)
    {
    }
}