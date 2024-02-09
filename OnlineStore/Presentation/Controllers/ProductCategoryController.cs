using Application.CQRS.ProductCategories.Commands;
using Application.CQRS.ProductCategories.Queries;
using Application.DTOs.ProductCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class ProductCategoryController : Controller
{
    private readonly IMediator _mediator;

    public ProductCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductCategoryAddDto productCategoryAddDto)
    {
        var addProductCategoryCommand = new AddProductCategoryCommand(productCategoryAddDto);
        var productCategory = await _mediator.Send(addProductCategoryCommand);

        return Ok(productCategory);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllProductCategoriesQuery = new GetAllProductCategoriesQuery();
        var productCategories = await _mediator.Send(getAllProductCategoriesQuery);

        return Ok(productCategories);
    }
}