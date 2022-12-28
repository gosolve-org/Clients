using GoSolve.Clients.Shared.Models;

namespace GoSolve.Clients.Dummy.Review.Contracts.Responses;

/// <summary>
/// Response DTO for Review.
/// </summary>
public class ReviewResponse : TimestampedResponse
{
    /// <summary>
    /// Id of the review.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Id of the book the review is for.
    /// </summary>
    public long BookId { get; set; }

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

    /// <summary>
    /// The type of the author of the review.
    /// </summary>
    public ReviewAuthorTypeResponse AuthorType { get; set; }
}

/// <summary>
/// Response DTO for review author type.
/// </summary>
public class ReviewAuthorTypeResponse
{
    /// <summary>
    /// The id of the type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the type.
    /// </summary>
    public string Type { get; set; }
}
