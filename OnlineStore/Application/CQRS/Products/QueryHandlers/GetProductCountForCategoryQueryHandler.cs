using Application.Abstractions.Services.ShopServices;
using Application.CQRS.Products.Queries;
using MediatR;

namespace Application.CQRS.Products.QueryHandlers;

public class GetProductCountForCategoryQueryHandler : IRequestHandler<GetProductCountForCategoryQuery, int>
{
    private readonly IProductHandlerService _productHandlerService;

    public GetProductCountForCategoryQueryHandler(IProductHandlerService productHandlerService)
    {
        _productHandlerService = productHandlerService;
    }

    public async Task<int> Handle(GetProductCountForCategoryQuery request, CancellationToken cancellationToken)
    {
        // TODO validation for category id for existence
        var requestedCategoryId = request.CategoryId;
        var productCountForEachCategory = await _productHandlerService.CalculateProductCountForEachCategory();

        return productCountForEachCategory
            .Where(pair => pair.Key.Id == requestedCategoryId)
            .Select(pair => pair.Value).FirstOrDefault();
    }
}