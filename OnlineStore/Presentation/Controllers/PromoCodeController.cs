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

    [HttpPost]
    public async Task<IActionResult> Create(PromoCodeAddDto promoCodeAddDto)
    {
        
    }

    [HttpPatch]
    public async Task<IActionResult> Activate(int id)
    {
        
    }

    [HttpPut]
    public async Task<IActionResult> Deactivate(int id)
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        
    }
}