using System.Text.Json.Serialization;

namespace EntertainmentDB.Models;

[JsonDerivedType(typeof(Book), typeDiscriminator: "book")]
[JsonDerivedType(typeof(Game), typeDiscriminator: "game")]
[JsonDerivedType(typeof(Movie), typeDiscriminator: "movie")]
[JsonDerivedType(typeof(Show), typeDiscriminator: "show")]
[JsonDerivedType(typeof(Track), typeDiscriminator: "track")]
public abstract class Media : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public DateOnly ReleaseDate { get; set; }

    public virtual ICollection<Genre>? Genres { get; set; }

    public virtual ICollection<Tag>? Tags { get; set; }

    public virtual Franchise? Franchise { get; set; }
}
