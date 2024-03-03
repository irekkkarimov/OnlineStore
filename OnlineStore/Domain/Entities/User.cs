using Domain.Abstraction;

namespace Domain.Entities;

public class User : Entity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public double PersonalDiscount { get; set; }
    public UserRole Role { get; set; } = UserRole.Costumer;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}