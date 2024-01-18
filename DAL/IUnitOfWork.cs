namespace EntertainmentDB.DAL;

public interface IUnitOfWork
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class;

    public void Save();
}
