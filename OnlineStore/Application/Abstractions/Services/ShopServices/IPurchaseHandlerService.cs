using Application.DTOs.Purchase;

namespace Application.Abstractions.Services.ShopServices;

public interface IPurchaseHandlerService
{
    Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto);
}