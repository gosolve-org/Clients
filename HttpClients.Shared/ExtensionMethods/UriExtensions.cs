using System.Web;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

/// <summary>
/// Extension methods for uri's.
/// </summary>
public static class UriExtensions
{
    /// <summary>
    /// Add a query to a uri.
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static QueryBuilder AddQuery(this Uri uri, string name, string value)
    {
        var queryBuilder = new QueryBuilder(uri);
        return queryBuilder.AddQuery(name, value);
    }

    /// <summary>
    /// Add a query to a uri.
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static QueryBuilder AddQuery(this string uri, string name, string value)
    {
        var queryBuilder = new QueryBuilder(uri);
        return queryBuilder.AddQuery(name, value);
    }

    /// <summary>
    /// Encodes a uri part.
    /// </summary>
    /// <typeparam name="T">Type of the object to encode.</typeparam>
    /// <param name="uriParam"></param>
    /// <returns></returns>
    public static string UriEncode<T>(this T uriParam)
    {
        return Uri.EscapeDataString(uriParam.ToString());
    }
}
