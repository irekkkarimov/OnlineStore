using Application.Abstractions.CustomExceptions.UserBalance;
using Application.CQRS.UserBalance.Queries;
using Application.DTOs.UserBalance;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.UserBalance.QueryHandlers;

public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, GetUserBalanceDto>
{
    private readonly IUserBalanceRepository _balanceRepository;
    private readonly IMapper _mapper;

    public GetUserBalanceQueryHandler(IUserBalanceRepository balanceRepository, IMapper mapper)
    {
        _balanceRepository = balanceRepository;
        _mapper = mapper;
    }

    public async Task<GetUserBalanceDto> Handle(GetUserBalanceQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var userBalance = await _balanceRepository.GetByUserIdAsync(userId);

        if (userBalance is null)
            throw new WrongUserBalanceException("User not found");

        return _mapper.Map<GetUserBalanceDto>(userBalance);
    }
}