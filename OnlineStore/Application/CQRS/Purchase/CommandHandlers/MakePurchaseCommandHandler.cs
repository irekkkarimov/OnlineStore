using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.CQRS.Purchase.Commands;
using Application.DTOs.Purchase;
using MediatR;

namespace Application.CQRS.Purchase.CommandHandlers;

public class MakePurchaseCommandHandler : IRequestHandler<MakePurchaseCommand, PurchaseResultDto>
{
    private readonly IPurchaseHandlerService _purchaseHandlerService;
    private readonly IPurchaseValidationService _validationService;

    public MakePurchaseCommandHandler(IPurchaseHandlerService purchaseHandlerService, IPurchaseValidationService validationService)
    {
        _purchaseHandlerService = purchaseHandlerService;
        _validationService = validationService;
    }

    public async Task<PurchaseResultDto> Handle(MakePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchaseAddDto = request.PurchaseAddDto;
        await _validationService.ValidateAddingAsync(purchaseAddDto);

        var purchaseResultDto = await _purchaseHandlerService.MakePurchaseAsync(purchaseAddDto);
        return purchaseResultDto;
    }
}