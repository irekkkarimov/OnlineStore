using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.Commands;

public record AddToUserBalanceCommand(AddToUserBalanceDto AddToUserBalanceDto) : IRequest<GetUserBalanceDto>;