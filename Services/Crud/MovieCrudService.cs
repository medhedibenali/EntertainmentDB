using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class MovieCrudService(IUnitOfWork unitOfWork) : CrudService<Movie>(unitOfWork)
{
    public override Movie? GetById(object id)
    {
        return unitOfWork.Repository<Movie>()
            .Get(
                filter: m => m.Id.Equals(id),
                includeProperties: [
                    nameof(Movie.Genres),
                    nameof(Movie.Tags),
                    nameof(Movie.Franchise),
                    nameof(Movie.Stars),
                    nameof(Movie.Writers),
                    nameof(Movie.Directors),
                    nameof(Movie.Producers),
                    nameof(Movie.Soundtrack)
                ]
            )
            .FirstOrDefault();
    }

}
