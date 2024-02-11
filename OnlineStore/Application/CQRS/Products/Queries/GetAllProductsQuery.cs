using Application.DTOs.Product;
using MediatR;

namespace Application.CQRS.Products.Queries;

public record GetAllProductsQuery : IRequest<List<ProductGetDto>>;