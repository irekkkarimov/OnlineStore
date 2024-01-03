using Domain.Abstraction;

namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public ProductCategory? Category { get; set; }
}