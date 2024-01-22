namespace EntertainmentDB.Models;

public class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Origin { get; set; } = "";

    public virtual ICollection<Book>? BooksPublished { get; set; }

    public virtual ICollection<Game>? GamesDeveloped { get; set; }

    public virtual ICollection<Game>? GamesPublished { get; set; }

    public virtual ICollection<Movie>? MoviesProduced { get; set; }

    public virtual ICollection<Platform>? PlatformsDeveloped { get; set; }
}
