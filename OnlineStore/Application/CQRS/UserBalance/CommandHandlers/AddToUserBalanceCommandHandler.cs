using Application.Abstractions.Services.UserServices;
using Application.CQRS.UserBalance.Commands;
using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.CommandHandlers;

public class AddToUserBalanceCommandHandler : IRequestHandler<AddToUserBalanceCommand, GetUserBalanceDto>
{
    private readonly IUserBalanceHandlerService _handlerService;
    private readonly IUserBalanceValidationService _validationService;

    public AddToUserBalanceCommandHandler(IUserBalanceHandlerService handlerService, IUserBalanceValidationService validationService)
    {
        _handlerService = handlerService;
        _validationService = validationService;
    }

    public async Task<GetUserBalanceDto> Handle(AddToUserBalanceCommand request, CancellationToken cancellationToken)
    {
        var addToUserBalanceDto = request.AddToUserBalanceDto;
        _validationService.ValidateAddingToUserBalance(addToUserBalanceDto);

        var result = await _handlerService.AddToBalanceAsync(addToUserBalanceDto);

        return result.Item2;
    }
}