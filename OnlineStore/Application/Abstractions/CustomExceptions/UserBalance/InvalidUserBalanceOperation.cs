using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;

namespace Application.Abstractions.CustomExceptions.UserBalance;

public class InvalidUserBalanceOperation : BadRequestException
{
    public InvalidUserBalanceOperation(string message) : base(message)
    {
    }
}