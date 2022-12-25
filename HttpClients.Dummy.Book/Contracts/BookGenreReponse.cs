namespace GoSolve.HttpClients.Dummy.Book.Contracts;

/// <summary>
/// Response DTO for a genre of a book.
/// </summary>
public class BookGenreReponse
{
    /// <summary>
    /// Id of the genre.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the genre.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of the genre.
    /// </summary>
    public string Description { get; set; }
}
