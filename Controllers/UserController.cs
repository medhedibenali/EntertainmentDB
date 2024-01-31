using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntertainmentDB.Services;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService userService = userService;

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = userService.GetAll();
        return Ok(users);
    }

    [HttpPost("assign-role/{username}")]
    [Authorize]
    public async Task<IActionResult> AssignRole(string username, RoleInput roleInput)
    {
        try
        {
            await userService.AssignRole(username, roleInput);
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }

        return Ok();
    }
}
