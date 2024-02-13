using System.Security.Claims;
using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.CQRS.Purchase.Commands;
using Application.DTOs.Purchase;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class PurchaseController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly HttpContext _httpContext;

    public PurchaseController(IMediator mediator, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
        _httpContext = httpContextAccessor.HttpContext!;
    }

    [HttpPost]
    public async Task<IActionResult> MakePurchase([FromBody] PurchaseAddPostDto purchaseAddPostDto)
    {
        var userId = GetUserId();
        var purchaseAddDto = _mapper.Map<PurchaseAddDto>(purchaseAddPostDto);
        purchaseAddDto.UserId = userId;
        
        var makePurchaseCommand = new MakePurchaseCommand(purchaseAddDto);
        var purchaseResultDto = await _mediator.Send(makePurchaseCommand);

        return Ok(purchaseResultDto);
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