using Application.CQRS.Cart.Queries;
using Application.DTOs.CartItem;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.QueryHandlers;

public class GetUserCartItemsQueryHandler : IRequestHandler<GetUserCartItemsQuery, List<CartItemGetDto>>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public GetUserCartItemsQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task<List<CartItemGetDto>> Handle(GetUserCartItemsQuery request, CancellationToken cancellationToken)
    {
        // TODO validation for user for existence
        var userId = request.UserId;

        var cartItems = await _cartItemRepository.GetByUserIdAsync(userId);
        var cartItemGetDtos = cartItems
            .Select(i => _mapper.Map<CartItemGetDto>(i))
            .ToList();

        return cartItemGetDtos;
    }
}