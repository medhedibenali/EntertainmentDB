using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;
public class PersonCrudService(IUnitOfWork unitOfWork) : CrudService<Person>(unitOfWork)
{
}