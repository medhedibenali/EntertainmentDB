namespace EntertainmentDB.Models;

public class Tag : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public virtual ICollection<Media>? Media { get; set; }
}
