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
public class FranchiseController(ICrudService<Franchise> franchiseService, IMappingService<Franchise, FranchiseInput> mappingService)
    : CrudController<Franchise, FranchiseInput>(franchiseService, mappingService)
{
}
