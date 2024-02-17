namespace Application.Abstractions.CustomExceptions.Abstractions;

public abstract class CustomException : Exception
{
    public int StatusCode { get; }

    protected CustomException(string message, ExceptionType exceptionType) : base(message)
    {
        StatusCode = (int)exceptionType;
    }
}

public enum ExceptionType
{
    Unauthorized = 401,
    Forbidden = 403,
    BadRequest = 400,
    NotFound = 404,
    Conflict = 409
}