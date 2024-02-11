using Microsoft.AspNetCore.Mvc;
using EntertainmentDB.Services;
using EntertainmentDB.RequestModels;
using Microsoft.AspNetCore.Authorization;

namespace EntertainmentDB.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService roleService = roleService;

    [HttpGet]
    public IActionResult GetRoles()
    {
        var roles = roleService.GetAll();
        return Ok(roles);
    }

    [HttpPost]
    public async Task<IActionResult> Post(RoleInput roleInput)
    {
        await roleService.Insert(roleInput);
        return Created();
    }
}
