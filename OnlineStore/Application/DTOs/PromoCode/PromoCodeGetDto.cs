namespace Application.DTOs.PromoCode;

public class PromoCodeGetDto
{
    public int Id { get; set; }
    public string? Code { get; set; } = null!;
    public double Discount { get; set; }
    public int LimitOfUsages { get; set; }
    public int Usages { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ExpiresAt { get; set; }
}