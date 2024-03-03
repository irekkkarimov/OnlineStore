using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.CQRS.Products.Commands;
using Application.CQRS.Products.Queries;
using Application.DTOs.Product;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly HttpContext _httpContext;

    public ProductController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        _httpContext = httpContextAccessor.HttpContext!;
    }

    [Authorize(Roles = "Admin,Seller")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductAddDtoHttp productAddDtoHttp)
    {
        var userId = GetUserId();
        var productAddDto = _mapper.Map<ProductAddDto>(productAddDtoHttp);
        productAddDto.UserId = userId;
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
        var productRemoveDto = new ProductRemoveDto
        {
            UserId = GetUserId(),
            ProductId = productId
        };
        var removeProductCommand = new RemoveProductCommand(productRemoveDto);
        await _mediator.Send(removeProductCommand);

        return Ok(new { productId });
    }

    [Authorize(Roles = "Admin,Seller")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductUpdateDtoHttp productUpdateDtoHttp)
    {
        var productUpdateDto = _mapper.Map<ProductUpdateDto>(productUpdateDtoHttp);
        productUpdateDto.UserId = GetUserId();
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
    
    [NonAction]
    private int GetUserId()
    {
        var userIdClaim = _httpContext.User.Claims.FirstOrDefault(i => i.Type.Equals("userid"));

        if (userIdClaim is null)
            throw new InvalidTokenException("Invalid token");

        return int.Parse(userIdClaim.Value);
    }
}