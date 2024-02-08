using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class TrackCrudService(IUnitOfWork unitOfWork) : CrudService<Track>(unitOfWork)
{
    public override Track? GetById(object id)
    {
        return unitOfWork.Repository<Track>()
            .Get(
                filter: t => t.Id.Equals(id),
                includeProperties: [
                    nameof(Track.Genres),
                    nameof(Track.Tags),
                    nameof(Track.Franchise),
                    nameof(Track.Artists),
                    nameof(Track.Movies),
                    nameof(Track.Shows),
                    nameof(Track.Games)
                ]
            )
            .FirstOrDefault();
    }

}
