namespace Application.DTOs.UserBalance;

public class AddToUserBalanceDto
{
    public int UserId { get; set; }
    public double MoneyToAdd { get; set; }
}