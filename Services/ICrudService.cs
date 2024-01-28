namespace EntertainmentDB.Services;

public interface ICrudService<TEntity> where TEntity : class
{
    public IEnumerable<TEntity> GetAll();

    public TEntity? GetById(object id);

    public void Insert(TEntity entity);

    public void Delete(object id);

    public void Delete(TEntity entityToDelete);

    public void Update(TEntity entityToUpdate);
}
