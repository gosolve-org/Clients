using System.ComponentModel.DataAnnotations;

namespace GoSolve.HttpClients.Dummy.Review.Contracts;

/// <summary>
/// Request DTO for Review.
/// </summary>
public class ReviewRequest
{
    /// <summary>
    /// Id of the book the review is for.
    /// </summary>
    public int BookId { get; set; }

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
