namespace EntertainmentDB.Models;

public abstract class Media
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public virtual ICollection<Genre>? Genres { get; set; }

    public virtual ICollection<Tag>? Tags { get; set; }
}
