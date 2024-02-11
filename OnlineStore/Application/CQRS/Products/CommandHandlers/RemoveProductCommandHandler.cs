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
        var productId = request.ProductId;

        var productToRemove = await _productRepository.GetByIdAsync(productId);

        if (productToRemove is null)
            throw new WrongProduct("Product does not exist");

        await _productRepository.RemoveAsync(productToRemove);
    }
}