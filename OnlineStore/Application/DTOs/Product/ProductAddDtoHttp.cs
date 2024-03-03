namespace Application.DTOs.Product;

public class ProductAddDtoHttp
{
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public double Price { get; set; }
}