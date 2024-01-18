using System.Collections;
using EntertainmentDB.Data;

namespace EntertainmentDB.DAL;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext context = context;
    private Hashtable repositories = new();

    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var repository = (IRepository<TEntity>?)repositories[typeof(IRepository<TEntity>)];

        if (repository == null)
        {
            repository = new Repository<TEntity>(context);
            repositories[typeof(IRepository<TEntity>)] = repository;
        }

        return repository;
    }

    public void Save()
    {
        context.SaveChanges();
    }
}
