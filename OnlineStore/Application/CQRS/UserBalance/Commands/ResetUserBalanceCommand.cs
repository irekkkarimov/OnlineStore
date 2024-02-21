using MediatR;

namespace Application.CQRS.UserBalance.Commands;

public record ResetUserBalanceCommand(int UserId) : IRequest;