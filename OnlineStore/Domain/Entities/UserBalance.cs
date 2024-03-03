using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Abstraction;

namespace Domain.Entities;

public class UserBalance : Entity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; } = null!;
    public double Balance { get; set; }
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}