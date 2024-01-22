using Microsoft.EntityFrameworkCore;
using EntertainmentDB.Models;

namespace EntertainmentDB.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Episode> Episodes { get; set; }

    public DbSet<Franchise> Franchises { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Mode> Modes { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<Platform> Platforms { get; set; }

    public DbSet<Season> Seasons { get; set; }

    public DbSet<Show> Shows { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Track> Tracks { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(
            u =>
            {
                u.HasMany<Media>(u => u.Favourites)
                .WithMany();
            }
        );

        modelBuilder.Entity<Episode>(
            e =>
            {
                e.HasOne<Season>(e => e.Season)
                    .WithMany(s => s.Episodes)
                    .IsRequired();

                e.Property(e => e.Duration)
                    .IsRequired();

                e.Property(e => e.EpisodeNumber)
                    .IsRequired();
            }
        );
    }
}
