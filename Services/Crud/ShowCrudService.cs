using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class ShowCrudService(IUnitOfWork unitOfWork) : CrudService<Show>(unitOfWork)
{
    public override Show? GetById(object id)
    {
        return unitOfWork.Repository<Show>()
            .Get(
                filter: s => s.Id.Equals(id),
                includeProperties: [
                    nameof(Show.Genres),
                    nameof(Show.Tags),
                    nameof(Show.Franchise),
                    nameof(Show.Seasons),
                    nameof(Show.Stars),
                    nameof(Show.Creators),
                    nameof(Show.Soundtrack)
                ]
            )
            .FirstOrDefault();
    }
}
