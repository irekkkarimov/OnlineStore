using Application.DTOs.CartItem;
using MediatR;

namespace Application.CQRS.Cart.Commands;

public record AddProductToCartCommand(CartItemAddDto CartItemAddDto) : IRequest;