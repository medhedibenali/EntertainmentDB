using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class MovieCrudService(IUnitOfWork unitOfWork) : CrudService<Movie>(unitOfWork)
{
   
}
