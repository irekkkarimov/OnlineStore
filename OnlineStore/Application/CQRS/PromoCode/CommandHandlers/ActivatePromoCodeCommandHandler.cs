using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.CQRS.PromoCode.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.PromoCode.CommandHandlers;

public class ActivatePromoCodeCommandHandler : IRequestHandler<ActivatePromoCodeCommand>
{
    private readonly IPromoCodeHandlerService _handlerService;

    public ActivatePromoCodeCommandHandler(IPromoCodeHandlerService handlerService)
    {
        _handlerService = handlerService;
    }

    public async Task Handle(ActivatePromoCodeCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        await _handlerService.Activate(id);
    }
}