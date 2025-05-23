using System.Text.Json;

namespace WispersInTheHollow
{
  internal static class WorldCreator
  {
    private record WorldData(List<LocationData> Locations, List<ItemData> Items);
    private record ItemData(string Id, string Name, string Description, string Hint);
    private record LocationData(string Id, string Name, string Description, Dictionary<string, string> Exits, List<string> Items);

    private static JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    public static Location StartLocation()
    {
      var worldData = LoadWorldData("world.json");

      var items = CreateItems(worldData.Items);
      var locations = CreateLocations(worldData.Locations);
      LinkLocations(worldData.Locations, items, locations);

      return locations.First().Value;
    }

    private static WorldData LoadWorldData(string filePath)
    {
      var json = LoadJson(filePath);
      var worldData = JsonSerializer.Deserialize<WorldData>(json, jsonSerializerOptions);
      return worldData ?? throw new InvalidOperationException("Deserialization returned null");
    }

    private static string LoadJson(string filePath)
    {
      return File.ReadAllText(filePath) ?? throw new IOException("Failed to read file with resources");
    }

    private static Dictionary<string, Item> CreateItems(List<ItemData> itemData)
    {
      return itemData.Select(item => (item.Id, new Item(item.Name, item.Description, item.Hint))).ToDictionary();
    }

    private static Dictionary<string, Location> CreateLocations(List<LocationData> locData)
    {
      return locData.Select(location => (location.Id, new Location(location.Name, location.Description))).ToDictionary();
    }

    private static void LinkLocations(List<LocationData> locData, Dictionary<string, Item> items, Dictionary<string, Location> locations)
    {
      foreach (var loc in locData)
      {
        AddItemsToLocation(loc, items, locations);
        AddExitsToLocation(loc, locations);
      }
    }

    private static void AddItemsToLocation(LocationData loc, Dictionary<string, Item> items, Dictionary<string, Location> locations)
    {
      foreach (var itemId in loc.Items)
      {
        if (!items.TryGetValue(itemId, out var item))
          throw new Exception($"Item ID '{itemId}' not found for location '{loc.Id}'.");
        locations[loc.Id].AddItem(item);
      }
    }

    private static void AddExitsToLocation(LocationData loc, Dictionary<string, Location> locations)
    {
      foreach (var (dir, exitId) in loc.Exits)
      {
        if (!locations.TryGetValue(exitId, out var exit))
          throw new Exception($"Exit ID '{exitId}' not found for location '{loc.Id}'.");

        locations[loc.Id].AddExit(dir, exit);
      }
    }
  }
}
