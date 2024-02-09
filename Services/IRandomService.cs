using EntertainmentDB.Models;

namespace EntertainmentDB.Services;

public interface IRandomService
{
    public TEntity? GetRandom<TEntity>() where TEntity : Media;
}
