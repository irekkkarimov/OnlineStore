using Application.Abstractions.CustomExceptions.Abstractions.Purchase;
using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.HandlerServices;
using Application.DTOs.Purchase;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.HandlerServices;

public class PurchaseHandlerService : IPurchaseHandlerService
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPromoCodeHandlerService _promoCodeHandlerService;
    private readonly IMapper _mapper;

    public PurchaseHandlerService(IPurchaseRepository purchaseRepository, IUserRepository userRepository, IProductRepository productRepository, IMapper mapper, IPromoCodeHandlerService promoCodeHandlerService)
    {
        _purchaseRepository = purchaseRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _promoCodeHandlerService = promoCodeHandlerService;
    }

    public async Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto)
    {
        var user = await _userRepository.GetByIdAsync(purchaseAddDto.UserId);
        var product = await _productRepository.GetByIdAsync(purchaseAddDto.ProductId);
        
        var discountFromCode = await _promoCodeHandlerService.TryUse(purchaseAddDto.PromoCode);
        var personalDiscount = user!.PersonalDiscount;
        var defaultPrice = product!.Price;
        
        var personalDiscountReversed = 1 - personalDiscount;
        var promoCodeDiscountReversed = 1 - discountFromCode;
        var totalDiscountReversed = personalDiscountReversed * promoCodeDiscountReversed;
        var totalPrice = defaultPrice * totalDiscountReversed;
        
        if (totalPrice < 0)
            throw new InvalidPurchaseException("Total price is less than 0");

        var purchase = _mapper.Map<Purchase>(purchaseAddDto);
        purchase.Discount = 1 - totalDiscountReversed;
        purchase.TotalPrice = totalPrice;
        // TODO use user balance for purchases

        await _purchaseRepository.AddAsync(purchase);
        var purchaseResultDto = _mapper.Map<PurchaseResultDto>(purchase);
        
        return purchaseResultDto;
    }
}