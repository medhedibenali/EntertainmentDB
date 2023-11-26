namespace EntertainmentDB.Models;

public class Franchise
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public virtual ICollection<Person>? Creators { get; set; }

    public virtual ICollection<Media>? Media { get; set; }
}
