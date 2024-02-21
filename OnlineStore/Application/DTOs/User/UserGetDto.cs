using Domain.Abstraction;

namespace Application.DTOs.User;

public class UserGetDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public double PersonalDiscount { get; set; }
    public UserRole Role { get; set; }
}