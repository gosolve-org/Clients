using GoSolve.Clients.Dummy.Review.Contracts.Requests;
using GoSolve.Clients.Dummy.Review.Contracts.Responses;

namespace GoSolve.Clients.Dummy.Review.HttpClients.Interfaces;

/// <summary>
/// HttpClient for reviews.
/// </summary>
public interface IReviewHttpClient
{
    /// <summary>
    /// Get a review by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ReviewResponse> GetById(long id);

    /// <summary>
    /// Gets all reviews by filters.
    /// </summary>
    /// <param name="author">Filter by author (required parameter).</param>
    /// <returns></returns>
    Task<IEnumerable<ReviewResponse>> GetByFilters(string author);

    /// <summary>
    /// Get all reviews for a book.
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns></returns>
    Task<IEnumerable<ReviewResponse>> GetForBook(long bookId);

    /// <summary>
    /// Add a review.
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    Task<ReviewResponse> Add(ReviewCreationRequest review);

    /// <summary>
    /// Update a review.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="review"></param>
    /// <returns></returns>
    Task<ReviewResponse> Update(long id, ReviewUpdateRequest review);
}
