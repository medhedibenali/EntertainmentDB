using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public abstract class MediaMappingService<TEntity, TEntityInput>(IUnitOfWork unitOfWork) : IMappingService<TEntity, TEntityInput>
    where TEntity : Media
    where TEntityInput : MediaInput
{
    protected readonly IUnitOfWork unitOfWork = unitOfWork;

    protected TEntity MapMedia(TEntityInput mediaInput, TEntity entity)
    {
        entity.Title = mediaInput.Title;
        entity.ReleaseDate = mediaInput.ReleaseDate;
        entity.Genres = mediaInput.Genres == null ? null
            : (IList<Genre>)unitOfWork.Repository<Genre>()
                .Get(filter: g => mediaInput.Genres.Contains(g.Id));
        entity.Tags = mediaInput.Tags == null ? null
            : (IList<Tag>)unitOfWork.Repository<Tag>()
                .Get(filter: t => mediaInput.Tags.Contains(t.Id));
        entity.Franchise = mediaInput.Franchise == null ? null
            : unitOfWork.Repository<Franchise>()
                .GetById(mediaInput.Franchise);

        return entity;
    }

    public abstract TEntity Map(TEntityInput entityInput);
}
