using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.Products.QueryHandlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductGetDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductGetDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        var productsDto = products
            .Select(i => _mapper.Map<ProductGetDto>(i))
            .ToList();

        return productsDto;
    }
}