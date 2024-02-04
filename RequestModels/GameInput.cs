namespace EntertainmentDB.RequestModels;

public class GameInput : MediaInput
{
    public string Synopsis { get; set; } = "";

    public ICollection<Guid>? Developers { get; set; }

    public ICollection<Guid>? Publishers { get; set; }

    public ICollection<Guid>? Directors { get; set; }

    public ICollection<Guid>? Soundtrack { get; set; }

    public ICollection<Guid>? Platforms { get; set; }

    public ICollection<Guid>? Modes { get; set; }
}
