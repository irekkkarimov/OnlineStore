using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain.Abstraction;

namespace Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public int CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    [DataType("MONEY")] public double Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}