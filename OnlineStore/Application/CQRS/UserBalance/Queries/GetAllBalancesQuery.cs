using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.Queries;

public record GetAllBalancesQuery() : IRequest<List<GetUserBalanceDto>>;