using System.Text.Json;

namespace StoreApp.Web.Infrastructure.Extensions;

public static class SessionExtension
{
    public static void SetObject<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetObject<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        return data is null
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
    }
}