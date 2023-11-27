namespace EntertainmentDB.Models;

public class Mode
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public virtual ICollection<Game>? Games { get; set; }
}
