using Application.DTOs.CartItem;
using MediatR;

namespace Application.CQRS.Cart.Commands;

public record RemoveProductFromCartCommand(CartItemRemoveDto CartItemRemoveDto) : IRequest;