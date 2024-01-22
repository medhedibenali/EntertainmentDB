namespace EntertainmentDB.Models;

public class Person
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public DateOnly Birthday { get; set; }

    public string Origin { get; set; } = "";

    public virtual ICollection<Franchise>? Franchises { get; set; }

    public virtual ICollection<Movie>? Movies { get; set; }

    public virtual ICollection<Movie>? MoviesDirected { get; set; }

    public virtual ICollection<Movie>? MoviesWritten { get; set; }

    public virtual ICollection<Show>? Shows { get; set; }

    public virtual ICollection<Show>? ShowsCreated { get; set; }
}
