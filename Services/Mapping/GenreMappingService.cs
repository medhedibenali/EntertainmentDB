using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;
public abstract class GenreMappingService<TEntity, TEntityInput>(IUnitOfWork unitOfWork) : IMappingService<TEntity, TEntityInput>
	where TEntity : Genre
	where TEntityInput : GenreInput
{
	protected readonly IUnitOfWork unitOfWork = unitOfWork;
	protected TEntity MapGenre(TEntityInput genreInput, TEntity entity)
	{
		entity.Name = genreInput.Name;
		entity.Medias = genreInput.Medias == null ? null
			: (IList<Media>)unitOfWork.Repository<Media>()
				.Get(filter: m => genreInput.Medias.Contains(m.Id));

		return entity;
	}

	public abstract TEntity Map(TEntityInput entityInput);
}