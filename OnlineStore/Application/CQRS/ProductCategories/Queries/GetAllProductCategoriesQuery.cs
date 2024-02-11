using Application.DTOs.ProductCategory;
using MediatR;

namespace Application.CQRS.ProductCategories.Queries;

public record GetAllProductCategoriesQuery : IRequest<List<ProductCategoryGetDto>>;