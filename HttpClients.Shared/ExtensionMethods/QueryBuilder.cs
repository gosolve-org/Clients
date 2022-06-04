using System.Collections.Specialized;
using System.Web;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

public class QueryBuilder
{
    private NameValueCollection _query;
    private UriBuilder _uriBuilder;

    public QueryBuilder(string baseUri)
    {
        _uriBuilder = new UriBuilder(baseUri);
        _uriBuilder.Port = -1;
        _query = HttpUtility.ParseQueryString(_uriBuilder.Query);
    }

    public QueryBuilder(Uri baseUri)
    {
        _uriBuilder = new UriBuilder(baseUri);
        _uriBuilder.Port = -1;
        _query = HttpUtility.ParseQueryString(_uriBuilder.Query);
    }

    public QueryBuilder AddQuery(string name, string value)
    {
        _query[name] = value;
        return this;
    }

    public override string ToString()
    {
        _uriBuilder.Query = _query.ToString();
        return _uriBuilder.ToString();
    }
}
