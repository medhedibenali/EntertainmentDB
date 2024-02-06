namespace EntertainmentDB.Models;

public class Genre : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public virtual ICollection<Media>? Medias { get; set; }
}
