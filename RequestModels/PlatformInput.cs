namespace EntertainmentDB.RequestModels;

public class PlatformInput
{
    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public Guid Developer { get; set; }
}
