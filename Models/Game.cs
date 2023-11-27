namespace EntertainmentDB.Models;

public class Game : Media
{
    public string Synopsis { get; set; } = "";

    public virtual ICollection<Company>? Developers { get; set; }

    public virtual ICollection<Company>? Publishers { get; set; }

    public virtual ICollection<Person>? Directors { get; set; }

    public virtual ICollection<Track>? Soundtrack { get; set; }

    public virtual ICollection<Platform>? Platforms { get; set; }

    public virtual ICollection<Mode>? Modes { get; set; }
}
