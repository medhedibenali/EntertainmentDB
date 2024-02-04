using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class GameCrudService(IUnitOfWork unitOfWork) : CrudService<Game>(unitOfWork)
{
    public override Game? GetById(object id)
    {
        return unitOfWork.Repository<Game>()
            .Get(
                filter: g => g.Id.Equals(id),
                includeProperties: [
                    nameof(Game.Genres),
                    nameof(Game.Tags),
                    nameof(Game.Franchise),
                    nameof(Game.Developers),
                    nameof(Game.Publishers),
                    nameof(Game.Directors),
                    nameof(Game.Soundtrack),
                    nameof(Game.Platforms),
                    nameof(Game.Modes)
                ]
            )
            .FirstOrDefault();
    }
}
