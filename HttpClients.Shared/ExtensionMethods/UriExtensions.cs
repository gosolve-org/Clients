using System.Web;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

public static class UriExtensions
{
    public static QueryBuilder AddQuery(this Uri uri, string name, string value)
    {
        var queryBuilder = new QueryBuilder(uri);
        return queryBuilder.AddQuery(name, value);
    }

    public static QueryBuilder AddQuery(this string uri, string name, string value)
    {
        var queryBuilder = new QueryBuilder(uri);
        return queryBuilder.AddQuery(name, value);
    }

    public static string UriEncode<T>(this T uriParam)
    {
        return Uri.EscapeDataString(uriParam.ToString());
    }
}
