using System.ComponentModel.DataAnnotations;

namespace GoSolve.Clients.Dummy.Book.Contracts.Requests;

/// <summary>
/// Creation request DTO for Book.
/// </summary>
public class BookCreationRequest
{
    /// <summary>
    /// Title of the book.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    /// <summary>
    /// Amount of pages of the book.
    /// </summary>
    [Range(0, int.MaxValue)]
    public int AmountOfPages { get; set; }

    /// <summary>
    /// Id of the genre.
    /// </summary>
    public int GenreId { get; set; }
}
