using Application.Abstractions.Services.ShopServices;
using Application.Abstractions.Services.ShopServices.ValidationServices;
using Application.CQRS.Products.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.CommandHandlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductValidationService _productValidationService;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper, IProductValidationService productValidationService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _productValidationService = productValidationService;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var productAddDto = request.ProductAddDto;
        await _productValidationService.ValidateAddingAsync(productAddDto);

        var product = _mapper.Map<Product>(productAddDto);

        await _productRepository.AddAsync(product);
    }
}