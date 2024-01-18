namespace EntertainmentDB.Models;

public class Company
{
    public string Name { get; set; } = "";

    public string Origin { get; set; } = "";

    public virtual ICollection<Media>? Media { get; set; }
}
