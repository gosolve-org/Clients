using GoSolve.HttpClients.Dummy.Book.Contracts;

namespace GoSolve.HttpClients.Dummy.Book;

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
    Task<BookResponse> AddBook(BookPostRequest book);
}
