namespace EntertainmentDB.Models;

public class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public virtual ICollection<Media>? Media { get; set; }
}
