using System.Text;
using Newtonsoft.Json;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

/// <summary>
/// Extension methods with json logic.
/// </summary>
public static class JsonExtensions
{
    /// <summary>
    /// Serialize an object to json StringContent.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static StringContent AsJson(this object obj)
    {
        return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
    }
}
