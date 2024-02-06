using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class BookCrudService(IUnitOfWork unitOfWork) : CrudService<Book>(unitOfWork)
{
    
}
