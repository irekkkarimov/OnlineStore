using Application.CQRS.Products.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.QueryHandlers;

public class GetAllProductsByCategoryQueryHandler : IRequestHandler<GetAllProductsByCategoryQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsByCategoryQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var categoryId = request.CategoryId;
        var productsByCategory = await _productRepository.GetAllByCategoryIdAsync(categoryId);
        return productsByCategory;
    }
}