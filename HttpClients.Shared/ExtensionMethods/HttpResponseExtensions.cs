using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

public static class HttpResponseExtensions
{
    private static readonly ILogger _logger = Log.ForContext(typeof(HttpResponseExtensions));

    public static async Task ValidateSuccess(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return;

        var content = await response.Content.ReadAsStringAsync();
        ProblemDetails problemDetails = null;
        try
        {
            problemDetails = JsonConvert.DeserializeObject<ProblemDetails>(content);
        }
        catch
        {
        }

        if (problemDetails != null && !string.IsNullOrWhiteSpace(problemDetails.Title))
        {
            _logger.Error("Http request failed. {@StatusCode} {@ProblemDetails}", response.StatusCode, problemDetails);
            throw new Exception($"Http request failed: {response.StatusCode} - {problemDetails.Title}." +
                $"\n{problemDetails.Detail}");
        }
        else
        {
            _logger.Error("Http request failed. {@StatusCode} {@ResponseContent}",
                response.StatusCode, content.Length > 2000 ? content.Substring(0, 2000) : content);
            throw new Exception($"Http request failed: {response.StatusCode}.");
        }
    }

    public static async Task<T> AsContract<T>(this HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content);
    }
}
