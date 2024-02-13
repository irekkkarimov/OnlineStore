using Application.Abstractions.Services.ShopServices;
using Application.CQRS.Cart.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Cart.CommandHandlers;

public class RemoveUserCartItemsCommandHandler : IRequestHandler<RemoveUserCartItemsCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartItemValidationService _validationService;

    public RemoveUserCartItemsCommandHandler(ICartItemRepository cartItemRepository, ICartItemValidationService validationService)
    {
        _cartItemRepository = cartItemRepository;
        _validationService = validationService;
    }

    public async Task Handle(RemoveUserCartItemsCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        await _validationService.ValidateRemoveByUserIdAsync(userId);
        
        await _cartItemRepository.RemoveFromCartByUserIdAsync(userId);
    }
}