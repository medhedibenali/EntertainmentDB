namespace EntertainmentDB.RequestModels;

public class FranchiseInput
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public virtual ICollection<Guid>? Creators { get; set; }
}
