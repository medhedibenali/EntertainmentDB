using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntertainmentDB.Services;

namespace EntertainmentDB.Controllers;

[ApiController]
[Authorize]
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

    [HttpPost("{username}/Role/{roleName}")]
    public async Task<IActionResult> AssignRole(string username, string roleName)
    {
        try
        {
            await userService.AssignRole(username, roleName);
        }
        catch (Exception e)
        {
            return BadRequest(new { e.Message });
        }

        return Ok();
    }
}
