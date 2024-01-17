namespace EntertainmentDB.Models;

public class Tag
{
    public string Name { get; set; } = "";
    public virtual ICollection<Media>? Media { get; set; }

}
