namespace GoSolve.HttpClients.Dummy.Review.Contracts;

/// <summary>
/// Response DTO for Review.
/// </summary>
public class ReviewResponse
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
