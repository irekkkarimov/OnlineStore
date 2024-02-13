using Application.Abstractions.Services.ShopServices;
using Application.CQRS.Products.Queries;
using MediatR;

namespace Application.CQRS.Products.QueryHandlers;

public class GetProductCountForCategoryQueryHandler : IRequestHandler<GetProductCountForCategoryQuery, int>
{
    private readonly IProductHandlerService _productHandlerService;
    private readonly IProductValidationService _productValidationService;

    public GetProductCountForCategoryQueryHandler(IProductHandlerService productHandlerService, IProductValidationService productValidationService)
    {
        _productHandlerService = productHandlerService;
        _productValidationService = productValidationService;
    }

    public async Task<int> Handle(GetProductCountForCategoryQuery request, CancellationToken cancellationToken)
    {
        var requestedCategoryId = request.CategoryId;
        await _productValidationService.ValidateCategoryForCountAsync(requestedCategoryId);
        
        var productCountForEachCategory = await _productHandlerService.CalculateProductCountForEachCategory();

        return productCountForEachCategory
            .Where(pair => pair.Key.Id == requestedCategoryId)
            .Select(pair => pair.Value).FirstOrDefault();
    }
}