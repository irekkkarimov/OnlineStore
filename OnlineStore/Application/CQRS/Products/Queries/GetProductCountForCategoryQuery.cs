using MediatR;

namespace Application.CQRS.Products.Queries;

public record GetProductCountForCategoryQuery(int CategoryId) : IRequest<int>;