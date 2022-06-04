using GoSolve.HttpClients.Shared.ExtensionMethods;
using Xunit;

namespace GoSolve.HttpClients.Shared.UnitTests.ExtensionMethods;

public class QueryBuilderTests
{
    [Fact]
    public void QueryBuilderClass_BaseAddressWithTrailingSlash_AddsQueriesToUri()
    {
        string baseUri = "https://domain.com/";

        var builder = new QueryBuilder(baseUri)
            .AddQuery("a", "aValue")
            .AddQuery("b", "bValue");

        Assert.Equal("https://domain.com/?a=aValue&b=bValue", builder.ToString());
    }

    [Fact]
    public void QueryBuilderClass_BaseAddressWithoutTrailingSlash_AddsQueriesToUri()
    {
        string baseUri = "https://domain.com";

        var builder = new QueryBuilder(baseUri)
            .AddQuery("a", "aValue")
            .AddQuery("b", "bValue");

        Assert.Equal("https://domain.com/?a=aValue&b=bValue", builder.ToString());
    }
}
