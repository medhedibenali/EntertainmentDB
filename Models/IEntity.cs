namespace EntertainmentDB.Models;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
