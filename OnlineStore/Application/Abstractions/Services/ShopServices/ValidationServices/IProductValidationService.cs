using Application.DTOs.Product;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IProductValidationService
{
    
    Task ValidateAddingAsync(ProductAddDto productAddDto);
    Task ValidateUpdateAsync(ProductUpdateDto productUpdateDto);
    Task ValidateCategoryForCountAsync(int productCategoryId);
}