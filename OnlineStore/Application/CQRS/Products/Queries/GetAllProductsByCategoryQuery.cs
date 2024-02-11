using Domain.Entities;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record GetAllProductsByCategoryQuery(int CategoryId) : IRequest<List<Product>>;