using Domain.Entities;
using MediatR;

namespace Application.CQRS.Products.Commands;

public record AddProductCommand(Product Product) : IRequest<Product>;