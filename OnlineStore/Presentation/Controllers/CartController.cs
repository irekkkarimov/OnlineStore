using System.Security.Claims;
using Application.CQRS.Cart.Commands;
using Application.DTOs.CartItem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

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


    [Authorize]
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

    [Authorize]
    [HttpPost]
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

    private Claim? GetUserIdClaim()
    {
        return _httpContext.User.Claims.FirstOrDefault(i => i.Type.Equals("userid"));
    }
}