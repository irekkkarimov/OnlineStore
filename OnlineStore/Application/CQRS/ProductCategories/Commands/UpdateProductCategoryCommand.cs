using Application.DTOs.Product;
using Application.DTOs.ProductCategory;
using MediatR;

namespace Application.CQRS.ProductCategories.Commands;

public record UpdateProductCategoryCommand(ProductCategoryUpdateDto ProductCategoryUpdateDto) : IRequest;