using Domain.Entities;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record GetProductByIdQuery(int ProductId) : IRequest<Product>;