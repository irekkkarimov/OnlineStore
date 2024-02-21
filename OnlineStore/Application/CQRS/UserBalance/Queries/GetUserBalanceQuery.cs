using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.Queries;

public record GetUserBalanceQuery(int UserId) : IRequest<GetUserBalanceDto>;