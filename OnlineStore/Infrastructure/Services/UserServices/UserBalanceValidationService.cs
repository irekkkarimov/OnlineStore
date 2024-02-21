using Application.Abstractions.CustomExceptions.UserBalance;
using Application.Abstractions.Services.UserServices;
using Application.DTOs.UserBalance;

namespace Infrastructure.Services.UserServices;

public class UserBalanceValidationService : IUserBalanceValidationService
{
    public void ValidateAddingToUserBalance(AddToUserBalanceDto addToUserBalanceDto)
    {
        ValidateMoneyPositive(addToUserBalanceDto.MoneyToAdd);
    }

    public void ValidateSubtractionFromUserBalance(SubtractFromUserBalanceDto subtractFromUserBalanceDto)
    {
        ValidateMoneyPositive(subtractFromUserBalanceDto.MoneyToSubtract);
    }

    private void ValidateMoneyPositive(double money)
    {
        switch (money)
        {
            case 0:
                throw new InvalidUserBalanceOperation("0 money adding or subtracting");
            case < 0:
                throw new InvalidUserBalanceOperation("Negative money adding or subtracting");
        }
    }
}