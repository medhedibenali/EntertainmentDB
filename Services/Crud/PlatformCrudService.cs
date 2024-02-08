using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class PlatformCrudService(IUnitOfWork unitOfWork) : CrudService<Platform>(unitOfWork)
{
    public override Platform? GetById(object id)
    {
        return unitOfWork.Repository<Platform>()
            .Get(
                filter: p => p.Id.Equals(id),
                includeProperties: [
                    nameof(Platform.Developer),
                    nameof(Platform.Games)
                ]
            )
            .FirstOrDefault();
    }
}
