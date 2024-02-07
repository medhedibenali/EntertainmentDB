namespace EntertainmentDB.RequestModels;

public class BookInput : MediaInput
{
    public string Isbn { get; set; } = "";

    public string Synopsis { get; set; } = "";

    public ICollection<Guid>? Authors { get; set; }

    public ICollection<Guid>? Publishers { get; set; }
}
