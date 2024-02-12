using MediatR;

namespace Application.CQRS.Cart.Commands;

public record RemoveUserCartItemsCommand(int UserId) : IRequest;