using Application.DTOs.CartItem;
using MediatR;

namespace Application.CQRS.Cart.Queries;

public record GetUserCartItemsQuery(int UserId) : IRequest<List<CartItemGetDto>>;