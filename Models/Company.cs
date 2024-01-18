namespace EntertainmentDB.Models;

public class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Origin { get; set; } = "";

    public virtual ICollection<Media>? Media { get; set; }
}
