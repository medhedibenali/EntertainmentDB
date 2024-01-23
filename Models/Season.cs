namespace EntertainmentDB.Models;

public class Season
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public int SeasonNumber { get; set; }

    public int NumberOfEpisodes { get; set; }

    public virtual Show? Show { get; set; }

    public virtual ICollection<Episode>? Episodes { get; set; }
}
