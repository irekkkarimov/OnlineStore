using MediatR;

namespace Application.CQRS.Products.Commands;

public record RemoveProductCommand(int ProductId) : IRequest;