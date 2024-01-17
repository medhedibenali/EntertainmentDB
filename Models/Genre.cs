namespace EntertainmentDB.Models;

public class Genre
{
    public string Name { get; set; } = "";
    public virtual ICollection<Media>? Media { get; set; }
}
