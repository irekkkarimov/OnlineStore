using Domain.Entities;

namespace Application.Abstractions.Services.UserServices;

public interface ISessionHandlerService
{
    /// <summary>
    /// Searches for user's last session
    /// </summary>
    /// <param name="user">User who's session is needed</param>
    /// <returns></returns>
    Task<string> SearchSession(User user);
    
    /// <summary>
    /// Creates a session for a user
    /// </summary>
    /// <param name="user">User the session is created for</param>
    /// <returns></returns>
    Task<string> CreateSession(User user);
}