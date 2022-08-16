using System.ComponentModel.DataAnnotations;

namespace GoSolve.HttpClients.Dummy.Review.Contracts;

/// <summary>
/// Request DTO for adding a new Review.
/// </summary>
public class ReviewPostRequest
{
    /// <summary>
    /// Id of the book the review is for.
    /// </summary>
    public long BookId { get; set; }

    /// <summary>
    /// Author of the review.
    /// </summary>
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Author { get; set; }

    /// <summary>
    /// Rating of the book on a scale of 1 to 5.
    /// </summary>
    [Range(1, 5)]
    public int Rating { get; set; }

    /// <summary>
    /// Comment on the book.
    /// </summary>
    public string Comment { get; set; }
}

/// <summary>
/// Request DTO for PUT'ing a Review.
/// </summary>
public class ReviewPutRequest : ReviewPostRequest
{
    /// <summary>
    /// Id of the review to update.
    /// </summary>
    public long Id { get; set; }
}

/// <summary>
/// Request DTO for PATCHing a Review.
/// </summary>
public class ReviewPatchRequest : ReviewPostRequest
{
}
