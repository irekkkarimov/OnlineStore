using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.Services.ShopServices;
using Application.DTOs.Product;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices;

public class ProductValidationService : IProductValidationService
{
    private readonly IProductCategoryRepository _categoryRepository;

    public ProductValidationService(IProductCategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task ValidateAddingAsync(ProductAddDto productAddDto)
    {
        ValidateProductName(productAddDto.Name);
        await ValidateProductCategoryId(productAddDto.CategoryId);
    }

    public async Task ValidateUpdateAsync(ProductUpdateDto productUpdateDto)
    {
        ValidateProductName(productUpdateDto.Name);
        await ValidateProductCategoryId(productUpdateDto.CategoryId);
    }

    private void ValidateProductName(string productName)
    {
        if (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName))
            throw new InvalidProductException("Invalid product name");
    }

    private async Task ValidateProductCategoryId(int categoryId)
    {
        var category = await _categoryRepository.GetById(categoryId);
        if (category is null)
            throw new InvalidProductException("Invalid category id");
    }
}