using Domain.Entities;
using MediatR;

namespace Application.CQRS.ProductCategories.Queries;

public record GetProductCategoryQuery(int ProductCategoryId) : IRequest<ProductCategory>;