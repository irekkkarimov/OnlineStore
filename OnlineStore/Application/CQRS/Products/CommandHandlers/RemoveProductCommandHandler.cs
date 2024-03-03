using Application.Abstractions.CustomExceptions.Products;
using Application.CQRS.Products.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.CommandHandlers;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
{
    private readonly IProductRepository _productRepository;

    public RemoveProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var productRemoveDto = request.ProductRemoveDto;
        var productToRemove = await _productRepository.GetByIdAsync(productRemoveDto.ProductId);
        
        if (productToRemove is null)
            throw new WrongProduct("Product does not exist");

        if (productToRemove.UserId != productRemoveDto.UserId)
            throw new ForbiddenProductAccessException("User has no access to this product");

        await _productRepository.RemoveAsync(productToRemove);
    }
}