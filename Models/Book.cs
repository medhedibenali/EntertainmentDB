namespace EntertainmentDB.Models;

public class Book : Media
{
    public string Isbn { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public virtual ICollection<Person>? Authors { get; set; }

    public virtual ICollection<Company>? Publishers { get; set; }
}
