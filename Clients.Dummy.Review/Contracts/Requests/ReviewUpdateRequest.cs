using System.ComponentModel.DataAnnotations;

namespace GoSolve.Clients.Dummy.Review.Contracts.Requests;

/// <summary>
/// Request DTO for updating a Review.
/// </summary>
public class ReviewUpdateRequest : ReviewCreationRequest
{
    /// <summary>
    /// Id of the review to update.
    /// </summary>
    public long Id { get; set; }
}
