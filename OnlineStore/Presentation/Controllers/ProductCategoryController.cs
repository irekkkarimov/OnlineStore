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

    [HttpGet]
    [Route("{productCategoryId:int}")]
    public async Task<IActionResult> Get(int productCategoryId)
    {
        var getProductCategoryQuery = new GetProductCategoryQuery(productCategoryId);
        var productCategory = await _mediator.Send(getProductCategoryQuery);

        return Ok(productCategory);
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(int productCategoryId)
    {
        var removeProductCategoryCommand = new RemoveProductCategoryCommand(productCategoryId);
        await _mediator.Send(removeProductCategoryCommand);

        return Ok(new { productCategoryId });
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProductCategoryUpdateDto productCategoryUpdateDto)
    {
        var updateProductCategoryCommand = new UpdateProductCategoryCommand(productCategoryUpdateDto);
        await _mediator.Send(updateProductCategoryCommand);

        return Ok(new { productCategoryUpdateDto });
    }
}