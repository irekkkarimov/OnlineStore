using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class WrongPasswordException : NotFoundException
{
    public WrongPasswordException(string message) : base(message)
    {
    }
}