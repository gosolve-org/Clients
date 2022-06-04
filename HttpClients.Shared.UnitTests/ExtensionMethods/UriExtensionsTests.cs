using GoSolve.HttpClients.Shared.ExtensionMethods;
using Xunit;

namespace GoSolve.HttpClients.Shared.UnitTests.ExtensionMethods;

public class UriExtensionsTests
{
    [Theory]
    [InlineData(" ", "%20")]
    [InlineData("/", "%2F")]
    [InlineData("\\", "%5C")]
    [InlineData("!", "%21")]
    [InlineData("@", "%40")]
    [InlineData("#", "%23")]
    [InlineData("$", "%24")]
    [InlineData("%", "%25")]
    [InlineData("^", "%5E")]
    [InlineData("&", "%26")]
    [InlineData("*", "%2A")]
    [InlineData("(", "%28")]
    [InlineData(")", "%29")]
    [InlineData("+", "%2B")]
    [InlineData(",", "%2C")]
    [InlineData("<", "%3C")]
    [InlineData(">", "%3E")]
    [InlineData("?", "%3F")]
    [InlineData("=", "%3D")]
    public void UriEncode_ContainsSpecialCharacter_EncodesCharacter(string character, string expectedEncoding)
    {
        var uri = "https://domain.com/a{0}b";

        var encodedUri = string.Format(uri, character.UriEncode());

        Assert.Equal(string.Format(uri, expectedEncoding), encodedUri);
    }
}
