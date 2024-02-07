namespace EntertainmentDB.RequestModels;

public class TrackInput : MediaInput
{
    public string Duration { get; set; } = "";

    public ICollection<Guid>? Artists { get; set; }
}
