using Application.Abstractions.CustomExceptions.Products;
using Application.DTOs.Product;

namespace Application.Abstractions.Services.ShopServices.ValidationServices;

public interface IProductValidationService
{
    /// <summary>
    /// Validates adding a new Product
    /// </summary>
    /// <param name="productAddDto">A DTO containing information about a new Product</param>
    /// <exception cref="InvalidProductException">Invalid Product name</exception>
    Task ValidateAddingAsync(ProductAddDto productAddDto);
    
    /// <summary>
    /// Validates updating an existing Product
    /// </summary>
    /// <param name="productUpdateDto">A DTO containing information about a Product for update</param>
    /// <exception cref="InvalidProductException">Invalid Product name</exception>
    Task ValidateUpdateAsync(ProductUpdateDto productUpdateDto);
    
    /// <summary>
    /// Validates category for counting
    /// </summary>
    /// <param name="productCategoryId">id of ProductCategory Products are counted for</param>
    /// <exception cref="InvalidProductException">Invalid ProductCategory or Product name</exception>
    Task ValidateCategoryForCountAsync(int productCategoryId);
}