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
public class ModeController(ICrudService<Mode> modeService, IMappingService<Mode, ModeInput> mappingService)
    : CrudController<Mode, ModeInput>(modeService, mappingService)
{
}
