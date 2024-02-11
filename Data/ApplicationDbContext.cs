using Microsoft.EntityFrameworkCore;
using EntertainmentDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EntertainmentDB.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Episode> Episodes { get; set; }

    public DbSet<Franchise> Franchises { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<Media> Media { get; set; }

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

        modelBuilder.Entity<Game>(
            g =>
            {
                g.HasMany<Company>(g => g.Developers)
                .WithMany(c => c.GamesDeveloped);

                g.HasMany<Company>(g => g.Publishers)
                .WithMany(c => c.GamesPublished);
            }
        );

        modelBuilder.Entity<Movie>(
            m =>
            {
                m.HasMany<Person>(m => m.Stars)
                    .WithMany(p => p.Movies);

                m.HasMany<Person>(m => m.Writers)
                    .WithMany(p => p.MoviesWritten);

                m.HasMany<Person>(m => m.Directors)
                    .WithMany(p => p.MoviesDirected);
            }
        );

        modelBuilder.Entity<Show>(
            s =>
            {
                s.Property(s => s.NumberOfSeasons)
                    .IsRequired();

                s.HasMany<Person>(s => s.Stars)
                    .WithMany(p => p.Shows);

                s.HasMany<Person>(s => s.Creators)
                    .WithMany(p => p.ShowsCreated);
            }
        );

        modelBuilder.Entity<Season>(
            s =>
            {
                s.HasOne<Show>(s => s.Show)
                    .WithMany(s => s.Seasons)
                    .IsRequired();

                s.Property(s => s.SeasonNumber)
                    .IsRequired();
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

        modelBuilder.Entity<Platform>(
            p =>
            {
                p.HasOne<Company>(p => p.Developer)
                    .WithMany(c => c.PlatformsDeveloped)
                    .IsRequired();
            }
        );
    }
}
