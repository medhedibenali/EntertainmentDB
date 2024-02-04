namespace EntertainmentDB.RequestModels;

public abstract class MediaInput
{
    public string Title { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public ICollection<Guid>? Genres { get; set; }

    public ICollection<Guid>? Tags { get; set; }

    public Guid? Franchise { get; set; }
}
