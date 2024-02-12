namespace Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message, ExceptionType.NotFound)
    {
    }
}