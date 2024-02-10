using System.ComponentModel.DataAnnotations;
using Domain.Abstraction;

namespace Domain.Entities;

public class CartItem : Entity
{
    [Key]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    
    [Key]
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime CreatedAt { get; } = DateTime.Now;
}