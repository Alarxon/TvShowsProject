namespace TvShowsProject.Server.Models;

/// <summary>
/// TvShow Model, represents the TvShow entity
/// </summary>
public class TvShow
{
    /// <summary>
    /// The Id, unique key for each TvShow
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name, the TvShow name (can be NULL)
    /// </summary>
    public String? Name { get; set; }
    /// <summary>
    /// Favorie, if the TvShow is a favorite of the user (true or false)
    /// </summary>
    public bool Favorite { get; set; }
}