using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EntertainmentDB.Data;

namespace EntertainmentDB.DAL;

public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity> where TEntity : class
{
    internal ApplicationDbContext context = context;
    internal DbSet<TEntity> dbSet = context.Set<TEntity>();

    public virtual IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        IEnumerable<string>? includeProperties = null)
    {
        includeProperties ??= Enumerable.Empty<string>();
        includeProperties = includeProperties.Where(property => !string.IsNullOrWhiteSpace(property));

        IQueryable<TEntity> query = dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public virtual TEntity? GetById(object id)
    {
        return dbSet.Find(id);
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
        TEntity? entityToDelete = dbSet.Find(id);

        if (entityToDelete == null)
        {
            return;
        }

        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }

        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
