using Application.CQRS.Products.Commands;
using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin,Seller")]
    [HttpPost]
    public async Task<IActionResult> Add(ProductAddDto productAddDto)
    {
        var addProductCommand = new AddProductCommand(productAddDto);
        await _mediator.Send(addProductCommand);

        return Ok();
    }

    [HttpGet]
    [Route("{productId:int}")]
    public async Task<IActionResult> Get(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await _mediator.Send(getProductByIdQuery);

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await _mediator.Send(getAllProductsQuery);

        return Ok(products);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByCategory(int categoryId)
    {
        var getAllProductsQuery = new GetAllProductsByCategoryQuery(categoryId);
        var products = await _mediator.Send(getAllProductsQuery);

        return Ok(products);
    }

    [Authorize(Roles = "Admin,Seller")]
    [HttpDelete]
    public async Task<IActionResult> Remove(int productId)
    {
        // TODO save seller's id when adding a product to make remove access
        var removeProductCommand = new RemoveProductCommand(productId);
        await _mediator.Send(removeProductCommand);

        return Ok(new { productId });
    }

    [Authorize(Roles = "Admin,Seller")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductUpdateDto productUpdateDto)
    {
        var updateProductCommand = new UpdateProductCommand(productUpdateDto);
        await _mediator.Send(updateProductCommand);

        return Ok(new { productUpdateDto });
    }

    [HttpGet]
    public async Task<IActionResult> GetProductCount(int categoryId)
    {
        var getProductCountForCategoryQuery = new GetProductCountForCategoryQuery(categoryId);
        var count = await _mediator.Send(getProductCountForCategoryQuery);

        return Ok(new { count });
    }
}