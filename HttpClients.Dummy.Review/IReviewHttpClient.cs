using GoSolve.HttpClients.Dummy.Review.Contracts;

namespace GoSolve.HttpClients.Dummy.Review;

/// <summary>
/// HttpClient for reviews.
/// </summary>
public interface IReviewHttpClient
{
    /// <summary>
    /// Gets all reviews with filters.
    /// </summary>
    /// <param name="author">Filter by author (required parameter).</param>
    /// <returns></returns>
    Task<IEnumerable<ReviewResponse>> GetReviews(string author);

    /// <summary>
    /// Get a review by its id.
    /// </summary>
    /// <param name="reviewId"></param>
    /// <returns></returns>
    Task<ReviewResponse> GetReviewById(int reviewId);

    /// <summary>
    /// Get all reviews for a book.
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns></returns>
    Task<IEnumerable<ReviewResponse>> GetReviewsForBook(int bookId);

    /// <summary>
    /// Add a review.
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    Task<ReviewResponse> AddReview(ReviewRequest review);
}
