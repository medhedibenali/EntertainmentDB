using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;
public abstract class PersonMappingService<TEntity, TEntityInput>(IUnitOfWork unitOfWork) : IMappingService<TEntity, TEntityInput>
    where TEntity : Person
    where TEntityInput : PersonInput
{
        protected readonly IUnitOfWork unitOfWork = unitOfWork;
        protected TEntity MapPerson(TEntityInput personInput, TEntity entity)
        {
            entity.FirstName = personInput.FirstName;
            entity.LastName = personInput.LastName;
            entity.Birthday = personInput.Birthday;
            entity.Origin = personInput.Origin;
            entity.Movies = personInput.Movies == null ? null
                : (IList<Movie>)unitOfWork.Repository<Movie>()
                    .Get(filter: m => personInput.Movies.Contains(m.Id));
            entity.MoviesDirected = personInput.MoviesDirected == null ? null
                : (IList<Movie>)unitOfWork.Repository<Movie>()
                    .Get(filter: m => personInput.MoviesDirected.Contains(m.Id));
            entity.MoviesWritten = personInput.MoviesWritten == null ? null
                : (IList<Movie>)unitOfWork.Repository<Movie>()
                    .Get(filter: m => personInput.MoviesWritten.Contains(m.Id));
            entity.Shows = personInput.Shows == null ? null
                : (IList<Show>)unitOfWork.Repository<Show>()
                    .Get(filter: s => personInput.Shows.Contains(s.Id));
            entity.ShowsCreated = personInput.ShowsCreated == null ? null
                : (IList<Show>)unitOfWork.Repository<Show>()
                    .Get(filter: s => personInput.ShowsCreated.Contains(s.Id));
            entity.GamesDirected = personInput.GamesDirected == null ? null
                : (IList<Game>)unitOfWork.Repository<Game>()
                    .Get(filter: g => personInput.GamesDirected.Contains(g.Id));
            entity.Books = personInput.Books == null ? null
                : (IList<Book>)unitOfWork.Repository<Book>()
                    .Get(filter: b => personInput.Books.Contains(b.Id));
            entity.Tracks = personInput.Tracks == null ? null
                : (IList<Track>)unitOfWork.Repository<Track>()
                    .Get(filter: t => personInput.Tracks.Contains(t.Id));
            entity.FranchisesCreated = personInput.FranchisesCreated == null ? null
                : (IList<Franchise>)unitOfWork.Repository<Franchise>()
                    .Get(filter: f => personInput.FranchisesCreated.Contains(f.Id));

            return entity;
        }

        public abstract TEntity Map(TEntityInput entityInput);
}


