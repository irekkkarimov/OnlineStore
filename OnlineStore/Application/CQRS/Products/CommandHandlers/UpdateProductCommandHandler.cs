using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.Services.ShopServices;
using Application.CQRS.Products.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.CommandHandlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductValidationService _productValidationService;

    public UpdateProductCommandHandler(IProductRepository productRepository,
        IProductValidationService productValidationService)
    {
        _productRepository = productRepository;
        _productValidationService = productValidationService;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productUpdateDto = request.ProductUpdateDto;
        await _productValidationService.ValidateUpdateAsync(productUpdateDto);

        var productFromDb = await _productRepository.GetByIdAsync(productUpdateDto.Id);

        if (productFromDb is null)
            throw new WrongProduct("Product does not exist");

        productFromDb.Name = productUpdateDto.Name;
        productFromDb.CategoryId = productUpdateDto.CategoryId;

        await _productRepository.UpdateAsync(productFromDb);
    }
}