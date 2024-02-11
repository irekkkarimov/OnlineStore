using Application.DTOs.ProductCategory;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.ProductCategories.Commands;

public record AddProductCategoryCommand(ProductCategoryAddDto ProductCategoryAddDto) : IRequest<ProductCategory>;