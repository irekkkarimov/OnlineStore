using Application.Abstractions.CustomExceptions.UserBalance;
using Application.DTOs.UserBalance;

namespace Application.Abstractions.Services.UserServices;

public interface IUserBalanceValidationService
{
    /// <summary>
    /// Validates adding currency to User's balance 
    /// </summary>
    /// <param name="addToUserBalanceDto">A DTO containing information about UserBalance and adding currency</param>
    /// <exception cref="InvalidUserBalanceOperation">Adding not positive amount of money</exception>
    void ValidateAddingToUserBalance(AddToUserBalanceDto addToUserBalanceDto);

    /// <summary>
    /// Validates adding currency to User's balance 
    /// </summary>
    /// <param name="subtractFromUserBalanceDto">A DTO containing information about UserBalance and subtracting currency</param>
    /// <exception cref="InvalidUserBalanceOperation">Subtracting not positive amount of money</exception>
    void ValidateSubtractionFromUserBalance(SubtractFromUserBalanceDto subtractFromUserBalanceDto);
}