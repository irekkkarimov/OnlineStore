using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.CQRS.User.Commands;
using Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class AuthController : Controller
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
    {
        var addUserCommand = new RegisterUserCommand(userRegisterDto);
        await _mediator.Send(addUserCommand);

        return Ok(userRegisterDto);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
    {
        var loginUserCommand = new LoginUserCommand(userLoginDto);
        var jwt = await _mediator.Send(loginUserCommand);

        return Ok(jwt);
    }


    /// <summary>
    /// Action used to check if client is authorized with jwt
    /// </summary>
    /// <returns>Json with some information</returns>
    [Authorize]
    [HttpGet]
    public IActionResult Validate()
    {
        return Ok(new { isAuthorized = true });
    }
}