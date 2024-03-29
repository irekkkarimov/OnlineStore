using Domain.Abstraction;

namespace Domain.Entities;

public class PromoCode : Entity
{
    public string Code { get; set; } = null!;
    public double Discount { get; set; }
    public int LimitOfUsages { get; set; }
    public int Usages { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ExpiresAt { get; set; }
}