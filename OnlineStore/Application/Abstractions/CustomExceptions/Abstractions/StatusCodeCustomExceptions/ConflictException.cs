namespace Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

public class ConflictException : CustomException
{
    public ConflictException(string message) : base(message, ExceptionType.Conflict)
    {
    }
}