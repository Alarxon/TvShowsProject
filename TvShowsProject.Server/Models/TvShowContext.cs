using Microsoft.EntityFrameworkCore;
namespace TvShowsProject.Server.Models;

/// <summary>
/// Database context that coordinates the Data Model, using the Entity Framework
/// </summary>
public class TvShowContext : DbContext
{
    /// <summary>
    /// Contructor for DbContext
    /// </summary>
    /// <param name="options">The DbContext options (this can change depending of which database are you using)</param>
    /// <returns>None, is the class contructor</returns>
    public TvShowContext(DbContextOptions<TvShowContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Overriding the onModelCreating to seed the in memory database
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder is injected when the model is created on load</param>
    /// <returns>None</returns>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TvShow>().HasData(
            new TvShow { Id = 1, Name = "Puella Magi Madoka Magica", Favorite = true },
            new TvShow { Id = 2, Name = "The Owl House", Favorite = true },
            new TvShow { Id = 3, Name = "Interview with the Vampire", Favorite = true },
            new TvShow { Id = 4, Name = "Game of Thrones", Favorite = false },
            new TvShow { Id = 5, Name = "Futurama", Favorite = false },
            new TvShow { Id = 6, Name = "Sword Art Online", Favorite = false }
        );
    }

    /// <summary>
    /// DbSet to query and save/modify instances of TvShow, is not NULL
    /// </summary>
    public DbSet<TvShow> TvShowItems { get; set; } = null!;
}