using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;
using EntertainmentDB.Services.Crud;
using EntertainmentDB.Services.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntertainmentDB.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PersonController(ICrudService<Person> personService, IMappingService<Person, PersonInput> mappingService) : CrudController<Person, PersonInput>(personService, mappingService)
    {
    }
}

