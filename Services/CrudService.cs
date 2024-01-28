using EntertainmentDB.DAL;

namespace EntertainmentDB.Services;

public class CrudService<TEntity>(IUnitOfWork unitOfWork) : ICrudService<TEntity> where TEntity : class
{
    protected readonly IUnitOfWork unitOfWork = unitOfWork;

    public virtual IEnumerable<TEntity> GetAll()
    {
        return unitOfWork.Repository<TEntity>()
            .Get();
    }

    public virtual TEntity? GetById(object id)
    {
        return unitOfWork.Repository<TEntity>()
            .GetById(id);
    }

    public virtual void Insert(TEntity entity)
    {
        unitOfWork.Repository<TEntity>()
            .Insert(entity);

        unitOfWork.Save();
    }

    public virtual void Delete(object id)
    {
        unitOfWork.Repository<TEntity>()
            .Delete(id);

        unitOfWork.Save();
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        unitOfWork.Repository<TEntity>()
            .Delete(entityToDelete);

        unitOfWork.Save();
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        unitOfWork.Repository<TEntity>()
            .Update(entityToUpdate);

        unitOfWork.Save();
    }
}
