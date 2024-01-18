namespace EntertainmentDB.Models;

public class Person
{
    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public DateOnly Birthday { get; set; }

    public string Origin { get; set; } = "";

    public virtual ICollection<Media>? Products { get; set; }

    public virtual ICollection<Franchise>? Franchises { get; set; }
}
