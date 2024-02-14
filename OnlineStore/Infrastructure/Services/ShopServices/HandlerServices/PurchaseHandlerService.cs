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
    private readonly IMapper _mapper;

    public PurchaseHandlerService(IPurchaseRepository purchaseRepository, IUserRepository userRepository, IProductRepository productRepository, IMapper mapper)
    {
        _purchaseRepository = purchaseRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PurchaseResultDto> MakePurchaseAsync(PurchaseAddDto purchaseAddDto)
    {
        // Did not implement PromoCode discount
        var user = await _userRepository.GetByIdAsync(purchaseAddDto.UserId);
        var product = await _productRepository.GetByIdAsync(purchaseAddDto.ProductId);
        var personalDiscount = user!.PersonalDiscount;
        var defaultPrice = product!.Price;
        var discountReversed = 1 - personalDiscount;
        var totalPrice = defaultPrice * discountReversed;
        
        if (totalPrice < 0)
            throw new InvalidPurchaseException("Total price is less than 0");

        var purchase = _mapper.Map<Purchase>(purchaseAddDto);
        purchase.Discount = personalDiscount;
        purchase.TotalPrice = totalPrice;

        await _purchaseRepository.AddAsync(purchase);
        var purchaseResultDto = _mapper.Map<PurchaseResultDto>(purchase);
        
        return purchaseResultDto;
    }
}