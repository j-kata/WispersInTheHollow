using System.Text.Json;

namespace WispersInTheHollow
{
  internal record WorldData
  {
    public List<LocationData> Locations { get; init; }
    public List<ItemData> Items { get; init; }
  }
  internal record ItemData {
    public string Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
  }
  internal record LocationData
  {
    public string Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public Dictionary<string, string> Exits { get; init; }
    public List<string> Items { get; init; }
  }

  internal static class WorldCreator
  {
    public static Location? StartLocation()
    {
      string json = "";
      try
      {
        json = File.ReadAllText("world.json");
      }
      catch (IOException ex)
      {
        Console.WriteLine(ex.Message);
      }

      var worldData = JsonSerializer.Deserialize<WorldData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

      if (worldData == null)
      {
        Console.WriteLine("Failed to deserialize");
        return null;
      }
      var items = CreateItems(worldData.Items);
      var locations = CreateLocations(worldData.Locations);

      LinkLocations(worldData.Locations, items, locations);
      return locations.First().Value;
    }

    private static Dictionary<string, Item> CreateItems(List<ItemData> itemData)
    {
      return itemData.Select(item => (item.Id, new Item(item.Name))).ToDictionary();
    }

    private static Dictionary<string, Location> CreateLocations(List<LocationData> locData)
    {
      return locData.Select(location => (location.Id, new Location(location.Name, location.Description))).ToDictionary();
    }

    private static void LinkLocations(List<LocationData> locData, Dictionary<string, Item> items, Dictionary<string, Location> locations)
    {
      foreach (var location in locData)
      {
        foreach (var item in location.Items)
          locations[location.Id].AddItem(items[item]);

        foreach (var exit in location.Exits)
          locations[location.Id].AddExit(exit.Key, locations[exit.Value]);
      }
    }
  }
}
