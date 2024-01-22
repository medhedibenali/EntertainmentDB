namespace EntertainmentDB.Models;

public class Show : Media
{
    public string Synopsis { get; set; } = "";

    public int NumberOfSeasons { get; set; }

    public virtual ICollection<Season>? Seasons { get; set; }

    public virtual ICollection<Person>? Stars { get; set; }

    public virtual ICollection<Person>? Creators { get; set; }

    public virtual ICollection<Track>? Soundtrack { get; set; }
}
