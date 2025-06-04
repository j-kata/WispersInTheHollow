using WispersInTheHollow.World.Data;

namespace WispersInTheHollow.World;

internal class WorldBuilder
{
    private readonly Dictionary<string, Item> _items;
    private readonly Dictionary<string, Location> _locations;

    public IReadOnlyDictionary<string, Location> Locations => _locations.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    public IReadOnlyDictionary<string, Item> Items => _items;

    public WorldBuilder()
    {
        var worldData = WorldCreator.Generate();

        _items = CreateItems(worldData.Items);
        _locations = CreateLocations(worldData.Locations);

        LinkLocations(worldData.Locations);
    }

    public Location StartLocation()
    {
        // TODO: add start position to json and return explicitly
        return Locations.First().Value;
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

