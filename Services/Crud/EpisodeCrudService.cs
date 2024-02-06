using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class EpisodeCrudService(IUnitOfWork unitOfWork) : CrudService<Episode>(unitOfWork)
{
    public override Episode? GetById(object id)
    {
        return unitOfWork.Repository<Episode>()
            .Get(filter: t => t.Id.Equals(id), includeProperties: [nameof(Episode.Season)])
            .FirstOrDefault();
    }
}
