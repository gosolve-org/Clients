namespace GoSolve.HttpClients.Dummy.Book.Contracts;

/// <summary>
/// Response DTO for Book.
/// </summary>
public class DetailedBookResponse
{
    /// <summary>
    /// Id of the book.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the book.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Amout of pages of the book.
    /// </summary>
    public int AmountOfPages { get; set; }

    /// <summary>
    /// The reviews of the book.
    /// </summary>
    public IEnumerable<DetailedBookReviewResponse> Reviews { get; set; }
}

/// <summary>
/// Response DTO for a review of a book.
/// </summary>
public class DetailedBookReviewResponse
{
    /// <summary>
    /// Id of the review.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Id of the book the review is for.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Author of the review.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Rating of the book on a scale of 1 to 5.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Comment on the book.
    /// </summary>
    public string Comment { get; set; }
}
