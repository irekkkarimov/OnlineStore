namespace Application.DTOs.Purchase;

public class PurchaseAddPostDto
{
    public int ProductId { get; set; }

    public string PromoCode { get; set; } = "";
    // public bool IsBuyingFromCart { get; set; } = false;
}