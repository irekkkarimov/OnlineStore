using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserBalance;

public class WrongUserBalanceException : NotFoundException
{
    public WrongUserBalanceException(string message) : base(message)
    {
    }
}