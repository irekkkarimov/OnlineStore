using Application.CQRS.Products.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.CommandHandlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Product;
        var isSuccess = await _productRepository.Add(product);
        return product;
    }
}