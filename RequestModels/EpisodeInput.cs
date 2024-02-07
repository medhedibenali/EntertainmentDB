namespace EntertainmentDB.RequestModels;

public class EpisodeInput
{
    public string Title { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public int Duration { get; set; }

    public int EpisodeNumber { get; set; }

    public Guid Season { get; set; }
}
