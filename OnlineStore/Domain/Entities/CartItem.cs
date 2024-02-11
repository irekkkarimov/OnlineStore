using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    
    [DataType("TIMESTAMP")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}