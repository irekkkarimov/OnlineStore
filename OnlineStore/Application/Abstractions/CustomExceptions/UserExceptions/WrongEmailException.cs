using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserExceptions;

public class WrongEmailException : NotFoundException
{
    public WrongEmailException(string message) : base(message)
    {
    }
}