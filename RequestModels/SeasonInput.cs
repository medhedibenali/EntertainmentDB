namespace EntertainmentDB.RequestModels;

public class SeasonInput
{
    public string Title { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public int SeasonNumber { get; set; }

    public int NumberOfEpisodes { get; set; }

    public Guid Show { get; set; }
}
