namespace Application.DTOs.Purchase;

public class PurchaseAddDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string PromoCode { get; set; } = "";
    // public bool IsBuyingFromCart { get; set; } = false;
}