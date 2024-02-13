using Application.Abstractions.Services.ShopServices;
using Application.DTOs.Purchase;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.HandlerServices;

public class PurchaseHandlerService : IPurchaseHandlerService
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseHandlerService(IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto)
    {
        // TODO implement
        throw new NotImplementedException();
    }
}