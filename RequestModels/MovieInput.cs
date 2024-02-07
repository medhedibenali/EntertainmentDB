namespace EntertainmentDB.RequestModels;

public class MovieInput : MediaInput
{
    public string Duration { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public ICollection<Guid>? Stars { get; set; }

    public ICollection<Guid>? Writers { get; set; }

    public ICollection<Guid>? Directors { get; set; }

    public ICollection<Guid>? Producers { get; set; }

    public ICollection<Guid>? Soundtrack { get; set; }
}
