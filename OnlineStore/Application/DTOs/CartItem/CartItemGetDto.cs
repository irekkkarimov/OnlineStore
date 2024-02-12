using Application.DTOs.Product;

namespace Application.DTOs.CartItem;

public class CartItemGetDto
{
    public int UserId { get; set; }
    public ProductGetDto Product { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}