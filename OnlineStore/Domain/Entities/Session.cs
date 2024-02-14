using Domain.Abstraction;

namespace Domain.Entities;

public class Session : Entity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime LoggedInAt { get; set; } = DateTime.Now;
    public DateTime TokenExpiresAt { get; set; }
}