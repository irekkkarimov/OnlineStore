using System.Security.Claims;
using Application.CQRS.Cart.Commands;
using Application.CQRS.Cart.Queries;
using Application.DTOs.CartItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class CartController : Controller
{
    private readonly IMediator _mediator;
    private readonly HttpContext _httpContext;

    public CartController(IHttpContextAccessor httpContextAccessor, IMediator mediator)
    {
        _httpContext = httpContextAccessor.HttpContext!;
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Add(int productId)
    {
        var userIdClaim = GetUserIdClaim();
        if (userIdClaim is null)
            return Forbid();

        var cartItemAddDto = new CartItemAddDto
        {
            UserId = int.Parse(userIdClaim.Value),
            ProductId = productId
        };
        var addProductToCartCommand = new AddProductToCartCommand(cartItemAddDto);
        await _mediator.Send(addProductToCartCommand);
        return Ok(new { productId });
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(int productId)
    {
        var userIdClaim = GetUserIdClaim();
        if (userIdClaim is null)
            return Forbid();

        var cartItemRemoveDto = new CartItemRemoveDto
        {
            UserId = int.Parse(userIdClaim.Value),
            ProductId = productId
        };
        var removeProductFroMCartCommand = new RemoveProductFromCartCommand(cartItemRemoveDto);
        await _mediator.Send(removeProductFroMCartCommand);
        return Ok(new { productId });
    }

    [HttpGet]
    public async Task<IActionResult> GetUserCart()
    {
        var userIdClaim = GetUserIdClaim();
        var userId = int.Parse(userIdClaim!.Value);
        var getUserCartItemsQuery = new GetUserCartItemsQuery(userId);
        var userCartItems = await _mediator.Send(getUserCartItemsQuery);

        return Ok(userCartItems);
    }

    [HttpDelete]
    public async Task<IActionResult> ClearUserCart()
    {
        var userIdClaim = GetUserIdClaim();
        var userId = int.Parse(userIdClaim!.Value);
        var removeUserCartItemsCommand = new RemoveUserCartItemsCommand(userId);
        await _mediator.Send(removeUserCartItemsCommand);

        return Ok();
    }

    private Claim? GetUserIdClaim()
    {
        return _httpContext.User.Claims.FirstOrDefault(i => i.Type.Equals("userid"));
    }
}