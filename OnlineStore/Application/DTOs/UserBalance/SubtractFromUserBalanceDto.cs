namespace Application.DTOs.UserBalance;

public class SubtractFromUserBalanceDto
{
    public int UserId { get; set; }
    public double MoneyToSubtract { get; set; }
}