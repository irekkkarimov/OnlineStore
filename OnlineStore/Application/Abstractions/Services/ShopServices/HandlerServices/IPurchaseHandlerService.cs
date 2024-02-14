using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices.HandlerServices;

public interface IPurchaseHandlerService
{
    Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto);
}