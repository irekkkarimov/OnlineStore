using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.CustomExceptions.UserBalance;
using Application.Abstractions.Services.UserServices;
using Application.DTOs.UserBalance;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services.UserServices;

public class UserBalanceHandlerService : IUserBalanceHandlerService
{
    private readonly IUserBalanceRepository _balanceRepository;
    private readonly IMapper _mapper;

    public UserBalanceHandlerService(IUserBalanceRepository balanceRepository, IMapper mapper)
    {
        _balanceRepository = balanceRepository;
        _mapper = mapper;
    }

    public async Task CreateUserBalanceAsync(int userId)
    {
        var checkIfExist = await _balanceRepository.GetByUserIdAsync(userId);

        if (checkIfExist is not null)
            throw new InvalidUserBalanceOperation("User balance already exists");

        var newUserBalance = new UserBalance
        {
            UserId = userId
        };

        await _balanceRepository.AddAsync(newUserBalance);
    }

    public async Task<(bool, GetUserBalanceDto)> AddToBalanceAsync(AddToUserBalanceDto addToUserBalanceDto)
    {
        var userBalanceFromDb = await _balanceRepository.GetByUserIdAsync(addToUserBalanceDto.UserId);

        ValidateUserBalanceNotNull(userBalanceFromDb);

        var newUserBalance = _mapper.Map<UserBalance>(addToUserBalanceDto);
        var previousBalance = userBalanceFromDb!.Balance;
        newUserBalance.Balance = previousBalance + addToUserBalanceDto.MoneyToAdd;
        
        var resultFromDb = await _balanceRepository.UpdateAsync(newUserBalance);

        var getUserBalanceDto = _mapper.Map<GetUserBalanceDto>(newUserBalance);

        if (resultFromDb)
            return (true, getUserBalanceDto);
        
        getUserBalanceDto.Balance = previousBalance;
        return (false, getUserBalanceDto);
    }
    
    public async Task<(bool, GetUserBalanceDto)> SubtractFromBalanceAsync(SubtractFromUserBalanceDto subtractFromUserBalanceDto)
    {
        var userBalanceFromDb = await _balanceRepository.GetByUserIdAsync(subtractFromUserBalanceDto.UserId);

        ValidateUserBalanceNotNull(userBalanceFromDb);

        var newUserBalance = _mapper.Map<UserBalance>(subtractFromUserBalanceDto);
        var previousBalance = userBalanceFromDb!.Balance;
        newUserBalance.Balance = previousBalance - subtractFromUserBalanceDto.MoneyToSubtract;
        
        var resultFromDb = await _balanceRepository.UpdateAsync(newUserBalance);

        var getUserBalanceDto = _mapper.Map<GetUserBalanceDto>(newUserBalance);

        if (resultFromDb)
            return (true, getUserBalanceDto);
        
        getUserBalanceDto.Balance = previousBalance;
        return (false, getUserBalanceDto);
    }

    public async Task ResetBalance(int userId)
    {
        var userBalance = await _balanceRepository.GetByUserIdAsync(userId);

        ValidateUserBalanceNotNull(userBalance);

        var newUserBalance = new UserBalance
        {
            UserId = userBalance!.UserId,
            Balance = 0
        };

        await _balanceRepository.UpdateAsync(newUserBalance);
    }

    private void ValidateUserBalanceNotNull(UserBalance? userBalance)
    {
        if (userBalance is null)
            throw new WrongUserBalanceException("User not found");
    }
}