using Application.Abstractions.CustomExceptions.Abstractions.StatusCodeCustomExceptions;
using Application.Abstractions.CustomExceptions.PromoCode;
using Application.DTOs.PromoCode;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IPromoCodeHandlerService
{
    /// <summary>
    /// Creates a PromoCode entity and handles saving it 
    /// </summary>
    /// <param name="promoCodeAddDto">A DTO used for creating a PromoCode</param>
    Task Create(PromoCodeAddDto promoCodeAddDto);

    /// <summary>
    /// Activates a deactivated PromoCode
    /// </summary>
    /// <param name="id">id of PromoCode to activate</param>
    /// <returns>bool representing success of an operation</returns>
    /// <exception cref="WrongPromoCodeException">PromoCode was not found</exception>
    /// <exception cref="ConflictException">PromoCode is already at state it was attempted to set to</exception>
    Task<bool> Activate(int id);

    /// <summary>
    /// Activates a deactivated PromoCode
    /// </summary>
    /// <param name="code">code of PromoCode to activate</param>
    /// <returns>bool representing success of an operation</returns>
    /// /// <exception cref="WrongPromoCodeException">PromoCode was not found</exception>
    /// <exception cref="ConflictException">PromoCode is already at state it was attempted to set to</exception>
    Task<bool> Activate(string code);

    /// <summary>
    /// Deactivates an active PromoCode     
    /// </summary>
    /// <param name="id">id of PromoCode to deactivate</param>
    /// <returns>bool representing success of an operation</returns>
    /// /// <exception cref="WrongPromoCodeException">PromoCode was not found</exception>
    /// <exception cref="ConflictException">PromoCode is already at state it was attempted to set to</exception>
    Task<bool> Deactivate(int id);

    /// <summary>
    /// Deactivates an active PromoCode     
    /// </summary>
    /// <param name="code">code of PromoCode to deactivate</param>
    /// <returns>bool representing success of an operation</returns>
    /// /// <exception cref="WrongPromoCodeException">PromoCode was not found</exception>
    /// <exception cref="ConflictException">PromoCode is already at state it was attempted to set to</exception>
    Task<bool> Deactivate(string code);

    /// <summary>
    /// Tries to use a PromoCode
    /// </summary>
    /// <param name="code">a code of PromoCode to use</param>
    /// <returns>Size of discount of PromoCode</returns>
    /// <exception cref="WrongPromoCodeException">PromoCode was not found or is not available</exception>
    Task<double> TryUse(string code);
}