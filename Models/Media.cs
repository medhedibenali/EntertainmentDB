namespace EntertainmentDB.Models;

public abstract class Media
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public ICollection<Genre>? Genres { get; set; }

    public ICollection<Tag>? Tags { get; set; }
}
