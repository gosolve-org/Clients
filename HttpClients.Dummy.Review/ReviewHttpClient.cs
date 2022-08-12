using GoSolve.HttpClients.Dummy.Review.Contracts;
using GoSolve.HttpClients.Shared.ExtensionMethods;
using GoSolve.Tools.Common.HttpClients;

namespace GoSolve.HttpClients.Dummy.Review;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ReviewHttpClient : IReviewHttpClient
{
    private const string VersionUri = "api/v1";
    private const string ReviewUri = "reviews";
    private const string BookUri = "books";

    private readonly HttpClient _httpClient;

    public ReviewHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ReviewResponse> Add(ReviewAddRequest review)
    {
        var response = await _httpClient.PostAsync($"{VersionUri}/{ReviewUri}", review.AsJson());
        await response.ValidateSuccess();

        return await response.AsContract<ReviewResponse>();
    }

    public async Task<ReviewResponse> Update(long id, ReviewUpdateRequest review)
    {
        var response = await _httpClient.PutAsync($"{VersionUri}/{ReviewUri}/{id}", review.AsJson());
        await response.ValidateSuccess();

        return await response.AsContract<ReviewResponse>();
    }

    public async Task<ReviewResponse> GetById(long reviewId)
    {
        var response = await _httpClient.GetAsync($"{VersionUri}/{ReviewUri}/{reviewId}");
        await response.ValidateSuccess();

        return await response.AsContract<ReviewResponse>();
    }

    public async Task<IEnumerable<ReviewResponse>> GetByFilters(string author)
    {
        var response = await _httpClient.GetAsync($"{VersionUri}/{ReviewUri}"
            .AddQuery("author", author)
            .ToString());
        await response.ValidateSuccess();

        return await response.AsContract<IEnumerable<ReviewResponse>>();
    }

    public async Task<IEnumerable<ReviewResponse>> GetForBook(long bookId)
    {
        var response = await _httpClient.GetAsync($"{VersionUri}/{BookUri}/{bookId.UriEncode()}/{ReviewUri}");
        await response.ValidateSuccess();

        return await response.AsContract<List<ReviewResponse>>();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
