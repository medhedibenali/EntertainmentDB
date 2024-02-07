using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;
using EntertainmentDB.Services.Crud;
using EntertainmentDB.Services.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDB.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class MovieController(ICrudService<Movie> movieService, IMappingService<Movie, MovieInput> mappingService)
    : CrudController<Movie, MovieInput>(movieService, mappingService)
{
}
