using Application.Abstractions.CustomExceptions.CartItemExceptions;
using Application.Abstractions.Services.ShopServices;
using Application.CQRS.Cart.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.CommandHandlers;

public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartItemValidationService _validationService;
    private readonly IMapper _mapper;

    public AddProductToCartCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper, ICartItemValidationService validationService)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _validationService = validationService;
    }

    public async Task Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
    {
        var cartItemAddDto = request.CartItemAddDto;
        await _validationService.ValidateAddingAsync(cartItemAddDto);
        var allCartItems = await _cartItemRepository.GetAllAsync();

        var checkIfCartItemExist =
            allCartItems.FirstOrDefault(i => i.UserId == cartItemAddDto.UserId && i.ProductId == cartItemAddDto.ProductId);

        if (checkIfCartItemExist is not null)
            throw new InvalidCartItemException("Current user already has this product in cart");

        var newCartItem = _mapper.Map<CartItem>(cartItemAddDto);
        await _cartItemRepository.AddAsync(newCartItem);
    }
}