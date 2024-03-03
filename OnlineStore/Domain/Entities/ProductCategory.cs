using Domain.Abstraction;

namespace Domain.Entities;

public class ProductCategory : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}