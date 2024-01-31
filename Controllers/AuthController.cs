using Microsoft.AspNetCore.Mvc;
using EntertainmentDB.Exceptions;
using EntertainmentDB.Services;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly IAuthService authService = authService;

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterCredentials credentials)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("User Registration Failed");
            }

            await authService.Register(credentials);

            return Ok(new { Message = "User Reigstration Successful" });
        }
        catch (AuthException e)
        {
            return new BadRequestObjectResult(new { e.Message, e.Errors });
        }
        catch (ArgumentException e)
        {
            return new BadRequestObjectResult(new { e.Message });
        }
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginCredentials credentials)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("Login failed");
            }

            var token = await authService.Login(credentials);

            return Ok(new { Token = token, Message = "Success" });
        }
        catch (ArgumentException e)
        {
            return new BadRequestObjectResult(new { e.Message });
        }
    }
}
