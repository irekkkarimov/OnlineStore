using Application.CQRS.Products.Commands;
using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using MediatR;
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

    [HttpPost]
    public async Task<IActionResult> Add(ProductAddDto productAddDto)
    {
        var addProductCommand = new AddProductCommand(productAddDto);
        await _mediator.Send(addProductCommand);
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await _mediator.Send(getAllProductsQuery);

        return Ok(products);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductCount(int categoryId)
    {
        var getProductCountForCategoryQuery = new GetProductCountForCategoryQuery(categoryId);
        var count = await _mediator.Send(getProductCountForCategoryQuery);

        return Ok(count);
    }
}