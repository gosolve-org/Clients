using System.Net;
using GoSolve.Clients.Shared.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace GoSolve.Clients.Shared.UnitTests.ExtensionMethods;

public class HttpResponseExtensionsTests
{
    [Theory]
    [InlineData(HttpStatusCode.OK)]
    [InlineData(HttpStatusCode.Created)]
    [InlineData(HttpStatusCode.NoContent)]
    public async Task ValidateSuccess_SuccessfulStatus_DoesNotThrowException(HttpStatusCode statusCode)
    {
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.StatusCode = statusCode;

        await httpResponseMessage.ValidateSuccess();
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.NotFound)]
    [InlineData(HttpStatusCode.RequestTimeout)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task ValidateSuccess_UnsuccessfulStatus_ThrowException(HttpStatusCode statusCode)
    {
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.StatusCode = statusCode;

        await Assert.ThrowsAsync<Exception>(() => httpResponseMessage.ValidateSuccess());
    }

    [Fact]
    public async Task ValidateSuccess_UnsuccessfulStatusAndInvalidJsonResponse_ThrowsExceptionWithStatusCode()
    {
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
        httpResponseMessage.Content = new StringContent("Invalid json error message");

        var ex = await Assert.ThrowsAsync<Exception>(() => httpResponseMessage.ValidateSuccess());
        Assert.Equal("Http request failed: BadRequest.", ex.Message);
    }

    [Fact]
    public async Task ValidateSuccess_UnsuccessfulStatusAndProblemDetailsResponse_ThrowsExceptionWithStatusCodeAndTitle()
    {
        var errorTitle = "error title";
        var errorDetail = "some extra details";
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
        httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(new ProblemDetails
        {
            Title = errorTitle,
            Detail = errorDetail,
            Type = "Some type",
            Status = 1234
        }));

        var ex = await Assert.ThrowsAsync<Exception>(() => httpResponseMessage.ValidateSuccess());
        Assert.Equal($"Http request failed: BadRequest - {errorTitle}.\n{errorDetail}", ex.Message);
    }

    [Fact]
    public async Task AsContract_NormalObject_ReturnsAsObject()
    {
        var json = "{\"testInt\":5,\"testString\":\"test\"}";
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.Content = new StringContent(json);

        var result = await httpResponseMessage.AsContract<TestJsonClass>();

        Assert.Equal(5, result.TestInt);
        Assert.Equal("test", result.TestString);
    }

    [Fact]
    public async Task AsContract_WithEnum_ReturnsWithEnum()
    {
        var json = "{\"testEnum\":\"a\"}";
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.Content = new StringContent(json);

        var result = await httpResponseMessage.AsContract<TestJsonClass>();

        Assert.Equal(TestEnum.A, result.TestEnum);
    }

    [Fact]
    public async Task AsContract_WithEnumNull_ReturnsWithEnumNull()
    {
        var json = "{\"testNullableEnum\":null}";
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.Content = new StringContent(json);

        var result = await httpResponseMessage.AsContract<TestJsonClass>();

        Assert.Null(result.TestNullableEnum);
    }

    [Fact]
    public async Task AsContract_WithInvalidJson_ThrowsJsonException()
    {
        var invalidJson = "{]";
        var httpResponseMessage = new HttpResponseMessage();
        httpResponseMessage.Content = new StringContent(invalidJson);

        await Assert.ThrowsAnyAsync<JsonException>(() => httpResponseMessage.AsContract<TestJsonClass>());
    }

    public class TestJsonClass
    {
        public int TestInt { get; set; }
        public string TestString { get; set; }
        public TestEnum TestEnum { get; set; }
        public TestEnum? TestNullableEnum { get; set; }
    }

    public enum TestEnum
    {
        A
    }
}
