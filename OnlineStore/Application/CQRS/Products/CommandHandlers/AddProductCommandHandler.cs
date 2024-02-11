using Application.CQRS.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.CommandHandlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var productAddDto = request.ProductAddDto;

        var product = _mapper.Map<Product>(productAddDto);

        await _productRepository.AddAsync(product);
    }
}