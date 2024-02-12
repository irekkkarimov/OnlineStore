using Application.Abstractions.CustomExceptions.ProductCategory;
using Application.CQRS.ProductCategories.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.ProductCategories.CommandHandlers;

public class RemoveProductCategoryCommandHandler : IRequestHandler<RemoveProductCategoryCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public RemoveProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task Handle(RemoveProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategoryId = request.ProductCategoryId;

        var productCategory = await _productCategoryRepository.GetByIdAsync(productCategoryId);

        if (productCategory is null)
            throw new WrongProductCategoryException("Product Category was not found");

        await _productCategoryRepository.RemoveAsync(productCategory);
    }
}