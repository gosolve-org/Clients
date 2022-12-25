using System.Collections.Specialized;
using System.Web;

namespace GoSolve.Clients.Shared.ExtensionMethods;

/// <summary>
/// Builder class used for building a uri with queries.
/// </summary>
public class QueryBuilder
{
    private NameValueCollection _query;
    private UriBuilder _uriBuilder;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="baseUri"></param>
    public QueryBuilder(string baseUri)
    {
        _uriBuilder = new UriBuilder(baseUri);
        _uriBuilder.Port = -1;
        _query = HttpUtility.ParseQueryString(_uriBuilder.Query);
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="baseUri"></param>
    public QueryBuilder(Uri baseUri)
    {
        _uriBuilder = new UriBuilder(baseUri);
        _uriBuilder.Port = -1;
        _query = HttpUtility.ParseQueryString(_uriBuilder.Query);
    }

    /// <summary>
    /// Adds a query to the builder.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public QueryBuilder AddQuery(string name, string value)
    {
        _query[name] = value;
        return this;
    }

    /// <summary>
    /// Builds the uri and returns the string representation with the added queries.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        _uriBuilder.Query = _query.ToString();
        return _uriBuilder.ToString();
    }
}
