using Application.CQRS.UserBalance.Commands;
using Application.CQRS.UserBalance.Queries;
using Application.DTOs.UserBalance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(Roles = "Admin")]
[Route("[controller]/[action]")]
public class BalanceController : Controller
{
    private readonly IMediator _mediator;

    public BalanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllBalancesQuery = new GetAllBalancesQuery();
        var allBalances = await _mediator.Send(getAllBalancesQuery);

        return Ok(allBalances);
    }

    [HttpGet]
    [Route("{userId:int}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var getUserBalanceQuery = new GetUserBalanceQuery(userId);
        var userBalance = await _mediator.Send(getUserBalanceQuery);

        return Ok(userBalance);
    }

    [HttpPut]
    public async Task<IActionResult> ResetUser(int userId)
    {
        var resetUserBalanceCommand = new ResetUserBalanceCommand(userId);
        await _mediator.Send(resetUserBalanceCommand);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> AddToUser(AddToUserBalanceDto addToUserBalanceDto)
    {
        var addToUserBalanceCommand = new AddToUserBalanceCommand(addToUserBalanceDto);
        var result = await _mediator.Send(addToUserBalanceCommand);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> SubtractFromUser(SubtractFromUserBalanceDto subtractFromUserBalanceDto)
    {
        var subtractFromUserBalanceCommand = new SubtractFromUserBalanceCommand(subtractFromUserBalanceDto);
        var result = await _mediator.Send(subtractFromUserBalanceCommand);

        return Ok(result);
    }
}