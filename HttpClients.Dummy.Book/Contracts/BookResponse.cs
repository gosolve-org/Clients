namespace GoSolve.HttpClients.Dummy.Book.Contracts;

/// <summary>
/// Response DTO for Book.
/// </summary>
public class BookResponse
{
    /// <summary>
    /// Id of the book.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Title of the book.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Amout of pages of the book.
    /// </summary>
    public int AmountOfPages { get; set; }

    /// <summary>
    /// Genre of the book.
    /// </summary>
    public BookGenreReponse Genre { get; set; }
}
