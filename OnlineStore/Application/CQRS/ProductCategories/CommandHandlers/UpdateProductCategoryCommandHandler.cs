using Application.Abstractions.CustomExceptions.ProductCategory;
using Application.CQRS.ProductCategories.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.ProductCategories.CommandHandlers;

public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategoryUpdateDto = request.ProductCategoryUpdateDto;

        var productCategoryFromDb = await _productCategoryRepository.GetByIdAsync(productCategoryUpdateDto.Id);

        if (productCategoryFromDb is null)
            throw new WrongProductCategoryException("Product Category was not found");

        productCategoryFromDb.Name = productCategoryUpdateDto.Name;
        productCategoryFromDb.Description = productCategoryUpdateDto.Description;

        await _productCategoryRepository.UpdateAsync(productCategoryFromDb);
    }
}