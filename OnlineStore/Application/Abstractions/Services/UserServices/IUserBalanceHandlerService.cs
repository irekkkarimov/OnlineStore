using Application.Abstractions.CustomExceptions.UserBalance;
using Application.DTOs.UserBalance;

namespace Application.Abstractions.Services.UserServices;

public interface IUserBalanceHandlerService
{
    /// <summary>
    /// Creates a UserBalance for a User
    /// </summary>
    /// <param name="userId">id of User a UserBalance is created for</param>
    /// <exception cref="InvalidUserBalanceOperation">User already has a UserBalance</exception>
    Task CreateUserBalanceAsync(int userId);
    
    /// <summary>
    /// Adds specific amount of currency to User's balance
    /// </summary>
    /// <param name="addToUserBalanceDto">A DTO containing information about the UserBalance and adding currency</param>
    /// <returns>bool: Success of operation, <see cref="GetUserBalanceDto"/>: A DTO representing UserBalance</returns>
    /// <exception cref="WrongUserBalanceException">User was not found</exception>
    Task<(bool, GetUserBalanceDto)> AddToBalanceAsync(AddToUserBalanceDto addToUserBalanceDto);
    
    /// <summary>
    /// Subtracts specific amount of currency from User's balance
    /// </summary>
    /// <param name="subtractFromUserBalanceDto">A DTO containing information about the UserBalance and subtracting currency</param>
    /// <returns>bool: Success of operation, <see cref="GetUserBalanceDto"/>: A DTO representing UserBalance</returns>
    /// <exception cref="WrongUserBalanceException">User was not found</exception>
    Task<(bool, GetUserBalanceDto)> SubtractFromBalanceAsync(SubtractFromUserBalanceDto subtractFromUserBalanceDto);
    
    /// <summary>
    /// Resets the balance of User
    /// </summary>
    /// <param name="userId">id of User whose balance is reset</param>
    /// <exception cref="WrongUserBalanceException">User was not found</exception>
    Task ResetBalance(int userId);
}