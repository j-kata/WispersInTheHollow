using System.Text.Json;

namespace WispersInTheHollow.World
{
  internal class WorldCreator
  {
    private record WorldData(List<LocationData> Locations, List<ItemData> Items);
    private record ItemData(string Id, string Name, string Description, string Hint);
    private record LocationData(string Id, string Name, string Description, Dictionary<string, string> Exits, List<string> Items);

    private static JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

    private readonly Dictionary<string, Item> _items;
    private readonly Dictionary<string, Location> _locations;

    public IReadOnlyDictionary<string, IReadOnlyLocation> Locations => _locations.ToDictionary(kvp => kvp.Key, kvp => (IReadOnlyLocation)kvp.Value);;
    public IReadOnlyDictionary<string, Item> Items => _items;

    public WorldCreator(string fileName = "World/world.json")
    {
      var worldData = LoadWorldData(fileName);

      _items = CreateItems(worldData.Items);
      _locations = CreateLocations(worldData.Locations);

      LinkLocations(worldData.Locations);
    }

    public IReadOnlyLocation StartLocation()
    {
      return Locations.First().Value;
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

    private void LinkLocations(List<LocationData> locData)
    {
      foreach (var loc in locData)
      {
        AddItemsToLocation(loc.Id, loc.Items);
        AddExitsToLocation(loc.Id, loc.Exits);
      }
    }

    private void AddItemsToLocation(string locationId, List<string> itemIds)
    {
      foreach (var itemId in itemIds)
      {
        if (!_items.TryGetValue(itemId, out var item))
          throw new Exception($"Item ID '{itemId}' not found for location '{locationId}'.");
        _locations[locationId].AddItem(item);
      }
    }

    private void AddExitsToLocation(string locationId, Dictionary<string, string> exits)
    {
      foreach (var (dir, exitId) in exits)
      {
        if (!_locations.TryGetValue(exitId, out var exit))
          throw new Exception($"Exit ID '{exitId}' not found for location '{locationId}'.");

        _locations[locationId].AddExit(dir, exit);
      }
    }
  }
}
