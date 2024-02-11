using Domain.Entities;

namespace Domain.Repositories;

public interface ICartItemRepository
{
    Task<bool> AddAsync(CartItem cartItem);
    Task<bool> RemoveFromCartAsync(CartItem cartItem);
    Task<List<CartItem>> GetAllAsync();
    Task<CartItem?> GetByIdAsync(int id);
    Task<List<CartItem>> GetByUserIdAsync(int userId);
}