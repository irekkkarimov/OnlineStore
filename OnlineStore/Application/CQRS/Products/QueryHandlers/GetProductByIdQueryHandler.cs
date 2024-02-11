using Application.Abstractions.CustomExceptions.Products;
using Application.CQRS.Products.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.QueryHandlers;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var productId = request.ProductId;
        var product = await _productRepository.GetByIdAsync(productId);

        if (product is null)
            throw new WrongProduct("Product does not exist");

        return product;
    }
}