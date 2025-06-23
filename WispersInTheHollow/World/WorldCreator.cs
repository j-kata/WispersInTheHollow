using System.Text.Json;
using WispersInTheHollow.World.Data;

namespace WispersInTheHollow.World;

internal class WorldCreator
{
    private const string defaultFile = "Data/world.json";

    public static WorldData Generate(string filePath = defaultFile)
    {
        var json = LoadJson(filePath);
        var worldData = DeserializeJson(json, new() { PropertyNameCaseInsensitive = true });
        return worldData ?? throw new InvalidOperationException("Deserialization returned null");
    }

    private static string LoadJson(string filePath)
    {
        return File.ReadAllText(filePath) ?? throw new IOException("Failed to read file with resources");
    }

    private static WorldData? DeserializeJson(string json, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<WorldData>(json, options);
    }
}
