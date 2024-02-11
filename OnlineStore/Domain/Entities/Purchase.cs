using Domain.Abstraction;

namespace Domain.Entities;

public class Purchase : Entity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int TotalPrice { get; set; }
    public int Discount { get; set; }
}