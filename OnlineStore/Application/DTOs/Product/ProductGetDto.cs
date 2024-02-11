using Application.DTOs.ProductCategory;

namespace Application.DTOs.Product;

public class ProductGetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ProductCategoryGetDto? Category { get; set; }
}