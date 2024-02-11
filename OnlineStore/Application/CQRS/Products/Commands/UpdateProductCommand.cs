using Application.DTOs.Product;
using MediatR;

namespace Application.CQRS.Products.Commands;

public record UpdateProductCommand(ProductUpdateDto ProductUpdateDto) : IRequest;