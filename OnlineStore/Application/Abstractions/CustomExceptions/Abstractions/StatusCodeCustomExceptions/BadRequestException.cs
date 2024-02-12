namespace Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message) : base(message, ExceptionType.BadRequest)
    {
    }
}