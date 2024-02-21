using Application.Abstractions.Services.UserServices;
using Application.CQRS.UserBalance.Commands;
using MediatR;

namespace Application.CQRS.UserBalance.CommandHandlers;

public class ResetUserBalanceCommandHandler : IRequestHandler<ResetUserBalanceCommand>
{
    private readonly IUserBalanceHandlerService _handlerService;

    public ResetUserBalanceCommandHandler(IUserBalanceHandlerService handlerService)
    {
        _handlerService = handlerService;
    }

    public async Task Handle(ResetUserBalanceCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;

        await _handlerService.ResetBalance(userId);
    }
}