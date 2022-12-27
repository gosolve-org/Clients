using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;
using GoSolve.Clients.Dummy.Book.HttpClients.Interfaces;
using GoSolve.Clients.Shared.ExtensionMethods;
using GoSolve.Tools.Common.Enumerations;
using GoSolve.Tools.Common.HttpClients;

namespace GoSolve.Clients.Dummy.Book.HttpClients;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class BookHttpClient : IBookHttpClient
{
    private const string BookUri = "api/v1/books";

    private readonly HttpClient _httpClient;

    public BookHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BookResponse> AddBook(BookCreationRequest book)
    {
        var response = await _httpClient.PostAsync(BookUri, book.AsJson());
        await response.ValidateSuccess();

        return await response.AsContract<BookResponse>();
    }

    public async Task<DetailedBookResponse> GetBookById(long id)
    {
        var response = await _httpClient.GetAsync($"{BookUri}/{id}");
        await response.ValidateSuccess();

        return await response.AsContract<DetailedBookResponse>();
    }

    public async Task<IEnumerable<BookResponse>> GetBooks()
    {
        var response = await _httpClient.GetAsync(BookUri);
        await response.ValidateSuccess();

        return await response.AsContract<IEnumerable<BookResponse>>();
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
