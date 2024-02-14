namespace Application.DTOs.Purchase;

public class PurchaseResultDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string Promocode { get; set; } = "";
    public double TotalPrice { get; set; }
    public double Discount { get; set; }
}