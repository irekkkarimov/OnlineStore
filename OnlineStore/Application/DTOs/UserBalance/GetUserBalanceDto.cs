namespace Application.DTOs.UserBalance;

public class GetUserBalanceDto
{
    public int UserId { get; set; }
    public double Balance { get; set; }
    public DateTime ModifiedAt { get; set; }
}