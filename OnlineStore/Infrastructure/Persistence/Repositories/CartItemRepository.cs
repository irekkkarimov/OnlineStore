using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly OnlineStoreDbContext _context;

    public CartItemRepository(OnlineStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(CartItem cartItem)
    {
        await _context.AddAsync(cartItem);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveFromCartAsync(CartItem cartItem)
    {
        _context.Remove(cartItem);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CartItem>> GetAllAsync()
    {
        var cartItems = _context.CartItems
            .Include(i => i.User)
            .Include(i => i.Product);
        return await cartItems.ToListAsync();
    }

    public async Task<CartItem?> GetByIdAsync(int id)
    {
        var cartItemQuery = _context.CartItems.Where(i => i.Id == id)
            .Include(i => i.User)
            .Include(i => i.Product);

        var cartItem = await cartItemQuery.FirstOrDefaultAsync();
        return cartItem;
    }

    public async Task<List<CartItem>> GetByUserIdAsync(int userId)
    {
        var cartItemsOfUserQuery = _context.CartItems.Where(i => i.UserId == userId)
            .Include(i => i.User)
            .Include(i => i.Product);

        var cartItemsOfUser = await cartItemsOfUserQuery.ToListAsync();
        return cartItemsOfUser;
    }
}