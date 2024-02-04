namespace EntertainmentDB.Services.Mapping;

public class MappingService<TEntity, TEntityInput> : IMappingService<TEntity, TEntityInput>
    where TEntity : class
    where TEntityInput : class, TEntity
{
    public TEntity Map(TEntityInput entityInput)
    {
        return (TEntity)entityInput;
    }
}
