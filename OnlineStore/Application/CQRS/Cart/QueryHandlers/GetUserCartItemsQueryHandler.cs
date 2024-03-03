using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.CQRS.Cart.Queries;
using Application.DTOs.CartItem;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.QueryHandlers;

public class GetUserCartItemsQueryHandler : IRequestHandler<GetUserCartItemsQuery, List<CartItemGetDto>>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartItemValidationService _validationService;
    private readonly IMapper _mapper;

    public GetUserCartItemsQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper, ICartItemValidationService validationService)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _validationService = validationService;
    }

    public async Task<List<CartItemGetDto>> Handle(GetUserCartItemsQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        await _validationService.ValidateGettingByUserIdAsync(userId);
        
        var cartItems = await _cartItemRepository.GetByUserIdAsync(userId);
        var cartItemGetDtos = cartItems
            .Select(i => _mapper.Map<CartItemGetDto>(i))
            .ToList();

        return cartItemGetDtos;
    }
}