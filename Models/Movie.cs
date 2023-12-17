namespace EntertainmentDB.Models;

public class Movie : Media
{
    public Guid Id { get; set; }

    public string Duration { get; set; } 

    public string Synopsis { get; set; } 

}
