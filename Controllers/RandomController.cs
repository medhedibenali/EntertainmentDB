using EntertainmentDB.Models;
using EntertainmentDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDB.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class RandomController(IRandomService randomService) : ControllerBase
{
    private readonly IRandomService randomService = randomService;

    [HttpGet]
    public IActionResult RandomMedia()
    {
        return Random<Media>();
    }

    [HttpGet("Book")]
    public IActionResult RandomBook()
    {
        return Random<Book>();
    }

    [HttpGet("Game")]
    public IActionResult RandomGame()
    {
        return Random<Game>();
    }

    [HttpGet("Movie")]
    public IActionResult RandomMovie()
    {
        return Random<Movie>();
    }

    [HttpGet("Show")]
    public IActionResult RandomShow()
    {
        return Random<Show>();
    }

    [HttpGet("Track")]
    public IActionResult RandomTrack()
    {
        return Random<Track>();
    }

    private IActionResult Random<TEntity>() where TEntity : Media
    {
        var entity = randomService.GetRandom<TEntity>();

        if (entity == null)
        {
            return NotFound();
        }

        return RedirectToAction("Get", entity.GetType().Name, new { Id = entity.Id });
    }
}
