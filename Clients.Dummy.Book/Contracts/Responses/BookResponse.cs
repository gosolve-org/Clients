using GoSolve.Clients.Shared.Models;

namespace GoSolve.Clients.Dummy.Book.Contracts.Responses;

/// <summary>
/// Response DTO for Book.
/// </summary>
public class BookResponse : TimestampedResponse
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
