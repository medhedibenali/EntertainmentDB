namespace EntertainmentDB.RequestModels;

public class ShowInput : MediaInput
{
    public string Synopsis { get; set; } = "";

    public int NumberOfSeasons { get; set; }

    public ICollection<Guid>? Stars { get; set; }

    public ICollection<Guid>? Creators { get; set; }

    public ICollection<Guid>? Soundtrack { get; set; }
}
