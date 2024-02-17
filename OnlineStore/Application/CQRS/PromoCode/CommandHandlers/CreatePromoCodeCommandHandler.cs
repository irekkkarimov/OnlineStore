using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.CQRS.PromoCode.Commands;
using MediatR;

namespace Application.CQRS.PromoCode.CommandHandlers;

public class CreatePromoCodeCommandHandler : IRequestHandler<CreatePromoCodeCommand>
{
    private readonly IPromoCodeHandlerService _handlerService;
    private readonly IPromoCodeValidationService _validationService;

    public CreatePromoCodeCommandHandler(IPromoCodeHandlerService handlerService, IPromoCodeValidationService validationService)
    {
        _handlerService = handlerService;
        _validationService = validationService;
    }

    public async Task Handle(CreatePromoCodeCommand request, CancellationToken cancellationToken)
    {
        var promoCodeAddDto = request.PromoCodeAddDto;
        _validationService.ValidateAdding(promoCodeAddDto);

        await _handlerService.Create(promoCodeAddDto);
    }
}