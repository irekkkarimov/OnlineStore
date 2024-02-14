namespace Application.DTOs.PromoCode;

public class PromoCodeAddDto
{
    public string Code { get; set; } = null!;
    public double Discount { get; set; }
    public int LimitOfUsages { get; set; }
    public string TimeNotParsed { get; set; } = null!;
}