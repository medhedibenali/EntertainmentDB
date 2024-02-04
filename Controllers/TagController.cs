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
public class TagController(ICrudService<Tag> tagService, IMappingService<Tag, TagInput> mappingService) : CrudController<Tag, TagInput>(tagService, mappingService)
{
}
