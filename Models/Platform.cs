namespace EntertainmentDB.Models;

public class Platform : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public virtual Company? Developer { get; set; }

    public virtual ICollection<Game>? Games { get; set; }
}
