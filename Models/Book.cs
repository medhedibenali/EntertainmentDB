namespace EntertainmentDB.Models;

public class Book : Media
{
    public Guid Id { get; set; }

    public string Isbn { get; set; } 

}
