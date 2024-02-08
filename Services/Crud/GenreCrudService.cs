using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class GenreCrudService(IUnitOfWork unitOfWork) : CrudService<Genre>(unitOfWork)
{
    public override Genre? GetById(object id)
    {
        return unitOfWork.Repository<Genre>()
            .Get(filter: g => g.Id.Equals(id), includeProperties: [nameof(Genre.Media)])
            .FirstOrDefault();
    }
}
