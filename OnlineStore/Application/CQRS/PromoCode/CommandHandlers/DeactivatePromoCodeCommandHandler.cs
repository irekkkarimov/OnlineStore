using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.CQRS.PromoCode.Commands;
using MediatR;

namespace Application.CQRS.PromoCode.CommandHandlers;

public class DeactivatePromoCodeCommandHandler : IRequestHandler<DeactivatePromoCodeCommand>
{
    private readonly IPromoCodeHandlerService _handlerService;

    public DeactivatePromoCodeCommandHandler(IPromoCodeHandlerService handlerService)
    {
        _handlerService = handlerService;
    }

    public async Task Handle(DeactivatePromoCodeCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        await _handlerService.Deactivate(id);
    }
}