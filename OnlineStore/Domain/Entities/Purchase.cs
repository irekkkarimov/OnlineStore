using Domain.Abstraction;

namespace Domain.Entities;

public class Purchase : Entity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string? PromoCode { get; set; }
    public double TotalPrice { get; set; }
    public double Discount { get; set; }
}