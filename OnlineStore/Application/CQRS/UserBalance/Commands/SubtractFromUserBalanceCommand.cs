using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.Commands;

public record SubtractFromUserBalanceCommand(SubtractFromUserBalanceDto SubtractFromUserBalanceDto) : IRequest<GetUserBalanceDto>;