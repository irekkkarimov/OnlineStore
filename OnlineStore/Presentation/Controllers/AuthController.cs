using Application.CQRS.User.Commands;
using Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        var addUserCommand = new RegisterUserCommand(userRegisterDto);
        await _mediator.Send(addUserCommand);

        return Ok(userRegisterDto);
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var loginUserCommand = new LoginUserCommand(userLoginDto);
        var jwt = await _mediator.Send(loginUserCommand);

        return Ok(jwt);
    }
}