using Application.CQRS.ProductCategories.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.ProductCategories.CommandHandlers;

public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommand, ProductCategory>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public AddProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }

    public async Task<ProductCategory> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategoryAddDto = request.ProductCategoryAddDto;
        var category = _mapper.Map<ProductCategory>(productCategoryAddDto);

        await _productCategoryRepository.Add(category);
        
        return category;
    }
}