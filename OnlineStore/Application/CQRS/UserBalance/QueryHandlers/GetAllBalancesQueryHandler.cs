using Application.CQRS.UserBalance.Queries;
using Application.DTOs.UserBalance;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.UserBalance.QueryHandlers;

public class GetAllBalancesQueryHandler : IRequestHandler<GetAllBalancesQuery, List<GetUserBalanceDto>>
{
    private readonly IUserBalanceRepository _balanceRepository;
    private readonly IMapper _mapper;

    public GetAllBalancesQueryHandler(IUserBalanceRepository balanceRepository, IMapper mapper)
    {
        _balanceRepository = balanceRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserBalanceDto>> Handle(GetAllBalancesQuery request, CancellationToken cancellationToken)
    {
        var allBalances = await _balanceRepository.GetAllAsync();

        var getUserBalanceDtos = allBalances
            .Select(i => _mapper.Map<GetUserBalanceDto>(i))
            .ToList();

        return getUserBalanceDtos;
    }
}