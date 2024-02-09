using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services;

public class RandomService(IUnitOfWork unitOfWork) : IRandomService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public TEntity? GetRandom<TEntity>() where TEntity : Media
    {
        var entities = (IList<TEntity>)unitOfWork.Repository<TEntity>()
                            .Get();

        var numberOfEntities = entities.Count();

        return numberOfEntities == 0 ? null
            : entities[Random.Shared.Next(numberOfEntities)];
    }
}
