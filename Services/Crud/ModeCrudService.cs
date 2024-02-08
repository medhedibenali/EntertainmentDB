using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class ModeCrudService(IUnitOfWork unitOfWork) : CrudService<Mode>(unitOfWork)
{
    public override Mode? GetById(object id)
    {
        return unitOfWork.Repository<Mode>()
            .Get(filter: m => m.Id.Equals(id), includeProperties: [nameof(Mode.Games)])
            .FirstOrDefault();
    }
}
