using Domain.Entities;

namespace Application.Abstractions.Services.UserServices;

public interface ISessionHandlerService
{
    Task<string> SearchSession(User user);
    Task<string> CreateSession(User user);
}