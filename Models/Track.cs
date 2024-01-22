namespace EntertainmentDB.Models;

public class Track : Media
{
    public string Duration { get; set; } = "";

    public virtual ICollection<Person>? Artists { get; set; }

    public virtual ICollection<Movie>? Movies { get; set; }

    public virtual ICollection<Show>? Shows { get; set; }
}
