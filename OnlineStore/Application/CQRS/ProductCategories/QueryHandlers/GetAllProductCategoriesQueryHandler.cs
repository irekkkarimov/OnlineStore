using Application.CQRS.ProductCategories.Queries;
using Application.DTOs.ProductCategory;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.ProductCategories.QueryHandlers;

public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, List<ProductCategoryGetDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllProductCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductCategoryGetDto>> Handle(GetAllProductCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetAll();

        return productCategories
            .Select(i => _mapper.Map<ProductCategoryGetDto>(i))
            .ToList();
    }
}