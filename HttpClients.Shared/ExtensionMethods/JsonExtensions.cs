using System.Text;
using Newtonsoft.Json;

namespace GoSolve.HttpClients.Shared.ExtensionMethods;

public static class JsonExtensions
{
    public static StringContent AsJson(this object obj)
    {
        return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
    }
}
