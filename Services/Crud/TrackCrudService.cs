using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class TrackCrudService(IUnitOfWork unitOfWork) : CrudService<Track>(unitOfWork)
{
    
}
