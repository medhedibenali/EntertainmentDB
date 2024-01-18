using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntertainmentDB.Models;

public class Season
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public int NumberOfEpisodes { get; set; }

    public Guid IdShow { get; set; }

    [ForeignKey(nameof(IdShow))]
    public virtual Show? Show { get; set; }

    public virtual ICollection<Episode>? Episodes { get; set; }

    public ICollection<Person>? Stars { get; set; }
}
