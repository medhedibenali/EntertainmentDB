namespace EntertainmentDB.Services.Mapping;

public interface IMappingService<TEntity, TEntityInput>
    where TEntity : class
    where TEntityInput : class
{
    public TEntity Map(TEntityInput entityInput);
}
