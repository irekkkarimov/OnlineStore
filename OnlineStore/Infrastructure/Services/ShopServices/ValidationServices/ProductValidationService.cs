using Application.Abstractions.CustomExceptions.Products;
using Application.Abstractions.Services.ShopServices;
using Application.DTOs.Product;
using Domain.Repositories;

namespace Infrastructure.Services.ShopServices.ValidationServices;

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
        await ValidateProductCategoryIdAsync(productAddDto.CategoryId);
    }

    public async Task ValidateUpdateAsync(ProductUpdateDto productUpdateDto)
    {
        ValidateProductName(productUpdateDto.Name);
        await ValidateProductCategoryIdAsync(productUpdateDto.CategoryId);
    }

    public async Task ValidateCategoryForCountAsync(int productCategoryId)
    {
        await ValidateProductCategoryIdAsync(productCategoryId);
    }

    private void ValidateProductName(string productName)
    {
        if (string.IsNullOrEmpty(productName) || string.IsNullOrWhiteSpace(productName))
            throw new InvalidProductException("Invalid product name");
    }

    private async Task ValidateProductCategoryIdAsync(int categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);
        if (category is null)
            throw new InvalidProductException("Invalid category id");
    }
}