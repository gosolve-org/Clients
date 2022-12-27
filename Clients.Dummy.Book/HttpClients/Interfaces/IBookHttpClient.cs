using GoSolve.Clients.Dummy.Book.Contracts.Requests;
using GoSolve.Clients.Dummy.Book.Contracts.Responses;

namespace GoSolve.Clients.Dummy.Book.HttpClients.Interfaces;

/// <summary>
/// HttpClient for books.
/// </summary>
public interface IBookHttpClient
{
    /// <summary>
    /// Get all books.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<BookResponse>> GetBooks();

    /// <summary>
    /// Get a book by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DetailedBookResponse> GetBookById(long id);

    /// <summary>
    /// Add a new book.
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<BookResponse> AddBook(BookCreationRequest book);
}
