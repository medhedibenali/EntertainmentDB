namespace EntertainmentDB.Models;

public class Movie : Media
{
    public string Duration { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public virtual ICollection<Person> Stars { get; set; }

    public virtual ICollection<Person>? Writers { get; set; }

    public virtual ICollection<Person>? Directors { get; set; }

    public virtual ICollection<Company>? Producers { get; set; }

    public virtual ICollection<Track>? Soundtrack { get; set; }
}
