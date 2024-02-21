using Application.CQRS.PromoCode.Commands;
using Application.CQRS.PromoCode.Queries;
using Application.DTOs.PromoCode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class PromoCodeController : Controller
{
    private readonly IMediator _mediator;

    public PromoCodeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]  PromoCodeAddDto promoCodeAddDto)
    {
        var createPromoCodeCommand = new CreatePromoCodeCommand(promoCodeAddDto);
        await _mediator.Send(createPromoCodeCommand);

        return Ok(promoCodeAddDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch]
    public async Task<IActionResult> Activate(int id)
    {
        var activatePromoCodeCommand = new ActivatePromoCodeCommand(id);
        await _mediator.Send(activatePromoCodeCommand);

        return Ok(new { promoCodeId = id });
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch]
    public async Task<IActionResult> Deactivate(int id)
    {
        var deactivatePromoCodeCommand = new DeactivatePromoCodeCommand(id);
        await _mediator.Send(deactivatePromoCodeCommand);

        return Ok(new { promoCodeId = id });
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllPromoCodesQuery = new GetAllPromoCodesQuery();
        var allPromoCodeGetDtos = await _mediator.Send(getAllPromoCodesQuery);

        return Ok(allPromoCodeGetDtos);
    }
}