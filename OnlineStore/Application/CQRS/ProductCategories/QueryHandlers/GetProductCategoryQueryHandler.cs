using Application.Abstractions.CustomExceptions.ProductCategory;
using Application.CQRS.ProductCategories.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.ProductCategories.QueryHandlers;

public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, ProductCategory>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public GetProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ProductCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
    {
        var productCategoryId = request.ProductCategoryId;

        var productCategory = await _productCategoryRepository.GetByIdAsync(productCategoryId);

        if (productCategory is null)
            throw new WrongProductCategoryException("Product Category was not found");

        return productCategory;
    }
}