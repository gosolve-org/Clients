using GoSolve.Clients.Shared.ExtensionMethods;
using Newtonsoft.Json;
using Xunit;

namespace GoSolve.Clients.Shared.UnitTests.ExtensionMethods;

public class JsonExtensionsTests
{
    [Fact]
    public async Task AsJson_ReturnsJson()
    {
        var myObj = new TestClass { Id = 5 };

        var json = await myObj.AsJson().ReadAsStringAsync();

        Assert.Equal(myObj.Id, JsonConvert.DeserializeObject<TestClass>(json).Id);
    }

    public class TestClass
    {
        public int Id { get; set; }
    }
}
