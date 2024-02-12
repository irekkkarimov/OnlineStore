using Application.CQRS.Cart.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.CommandHandlers;

public class RemoveUserCartItemsCommandHandler : IRequestHandler<RemoveUserCartItemsCommand>
{
    private readonly ICartItemRepository _cartItemRepository;

    public RemoveUserCartItemsCommandHandler(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task Handle(RemoveUserCartItemsCommand request, CancellationToken cancellationToken)
    {
        // TODO validation for user for existence
        var userId = request.UserId;

        await _cartItemRepository.RemoveFromCartByUserIdAsync(userId);
    }
}