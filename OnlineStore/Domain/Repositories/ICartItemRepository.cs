using Domain.Entities;

namespace Domain.Repositories;

public interface ICartItemRepository
{
    Task<bool> AddToCartAsync(int userId, Product product);
    Task<bool> RemoveFromCartAsync(int userId, Purchase purchase);
    Task<List<Cart>> GetAllCartsAsync();
    Task<Cart> GetByIdAsync(int id);
    Task<List<Product>> GetByUserIdAsync(int userId);
    Task<List<Purchase>> GetAllByUserIdAsync(int id);
}