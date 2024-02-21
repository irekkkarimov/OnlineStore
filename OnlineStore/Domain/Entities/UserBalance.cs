using Domain.Abstraction;

namespace Domain.Entities;

public class UserBalance : Entity
{
    // TODO make userid a key and remove id from table
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public double Balance { get; set; }
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
}