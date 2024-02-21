using Application.Abstractions.Services.UserServices;
using Application.CQRS.UserBalance.Commands;
using Application.DTOs.UserBalance;
using MediatR;

namespace Application.CQRS.UserBalance.CommandHandlers;

public class SubtractFromUserBalanceCommandHandler : IRequestHandler<SubtractFromUserBalanceCommand, GetUserBalanceDto>
{
    private readonly IUserBalanceHandlerService _handlerService;
    private readonly IUserBalanceValidationService _validationService;

    public SubtractFromUserBalanceCommandHandler(IUserBalanceHandlerService handlerService, IUserBalanceValidationService validationService)
    {
        _handlerService = handlerService;
        _validationService = validationService;
    }

    public async Task<GetUserBalanceDto> Handle(SubtractFromUserBalanceCommand request, CancellationToken cancellationToken)
    {
        var subtractFromUserBalanceDto = request.SubtractFromUserBalanceDto;
        _validationService.ValidateSubtractionFromUserBalance(subtractFromUserBalanceDto);

        var result = await _handlerService.SubtractFromBalanceAsync(subtractFromUserBalanceDto);
        return result.Item2;
    }
}