using Domain.Abstraction;

namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
}