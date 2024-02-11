namespace Application.DTOs.Product;

public class ProductGetAllDto
{
    public int Skip { get; set; } = 0;
    public int Count { get; set; } = int.MaxValue;
}