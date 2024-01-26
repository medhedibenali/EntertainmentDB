using System.Linq.Expressions;

namespace EntertainmentDB.DAL;

public interface IRepository<TEntity> where TEntity : class
{
    public IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        IEnumerable<string>? includeProperties = default);

    public TEntity? GetById(object id);

    public void Insert(TEntity entity);

    public void Delete(object id);

    public void Delete(TEntity entityToDelete);

    public void Update(TEntity entityToUpdate);
}
