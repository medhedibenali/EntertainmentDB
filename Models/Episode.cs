using System.ComponentModel.DataAnnotations;

namespace EntertainmentDB.Models;

public class Episode
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public string Synopsis { get; set; } = "";

    [Required]
    public int Duration { get; set; }

    public virtual Season? Season { get; set; }
}
