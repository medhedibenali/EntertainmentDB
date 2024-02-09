using EntertainmentDB.Models;
using EntertainmentDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDB.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ProfileController(IProfileService profileService) : ControllerBase
{
    private readonly IProfileService profileService = profileService;

    [HttpGet]
    public ActionResult<ApplicationUser> Get()
    {
        var currentUser = profileService.Get(User);

        if (currentUser == null)
        {
            return Unauthorized();
        }

        return Ok(currentUser);
    }

    [HttpPost("Favourite/{id}")]
    public async Task<IActionResult> AddFavourite(Guid id)
    {
        try
        {
            await profileService.AddFavorite(User, id);

            return NoContent();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (BadHttpRequestException)
        {
            return NotFound();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpDelete("Favourite/{id}")]
    public async Task<IActionResult> DeleteFavourite(Guid id)
    {
        try
        {
            await profileService.DeleteFavorite(User, id);

            return NoContent();
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch (BadHttpRequestException)
        {
            return NotFound();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}
