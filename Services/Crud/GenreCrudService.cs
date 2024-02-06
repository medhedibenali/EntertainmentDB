using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;
public class GenreCrudService(IUnitOfWork unitOfWork) : CrudService<Genre>(unitOfWork)
{
}