using System.ComponentModel.DataAnnotations;
using Domain.Abstraction;

namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
    [DataType("MONEY")] public double Price { get; set; }
}