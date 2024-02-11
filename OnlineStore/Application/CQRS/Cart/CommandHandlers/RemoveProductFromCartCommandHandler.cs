using Application.Abstractions.CustomExceptions.CartItemExceptions;
using Application.CQRS.Cart.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.CommandHandlers;

public class RemoveProductFromCartCommandHandler : IRequestHandler<RemoveProductFromCartCommand>
{
    private readonly ICartItemRepository _cartItemRepository;

    public RemoveProductFromCartCommandHandler(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
    {
        var cartItemRemoveDto = request.CartItemRemoveDto;

        var cartItemsOfUser = await _cartItemRepository.GetByUserIdAsync(cartItemRemoveDto.UserId);
        var cartItemToRemove = cartItemsOfUser.FirstOrDefault(i => i.ProductId == cartItemRemoveDto.ProductId);

        if (cartItemToRemove is null)
            throw new InvalidCartItemException("Current user does not have this product in cart");

        await _cartItemRepository.RemoveFromCartAsync(cartItemToRemove);
    }
}