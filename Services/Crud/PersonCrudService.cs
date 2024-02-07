using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;
public class PersonCrudService(IUnitOfWork unitOfWork) : CrudService<Person>(unitOfWork)
{ 
    public override Person? GetById(object id)
    {
        return unitOfWork.Repository<Person>()
            .Get(
                filter: p => p.Id.Equals(id),
                includeProperties: [
                    nameof(Person.Movies),
                    nameof(Person.MoviesDirected),
                    nameof(Person.MoviesDirected),
                    nameof(Person.MoviesWritten),
                    nameof(Person.Shows),
                    nameof(Person.ShowsCreated),
                    nameof(Person.GamesDirected),
                    nameof(Person.Books),
                    nameof(Person.Tracks),
                    nameof(Person.FranchisesCreated)
                ]
            )
            .FirstOrDefault();
    }
}