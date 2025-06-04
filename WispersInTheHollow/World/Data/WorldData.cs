namespace WispersInTheHollow.World.Data;

internal record WorldData(List<LocationData> Locations, List<ItemData> Items);
internal record ItemData(string Id, string Name, string Description, string Hint);
internal record LocationData(string Id, string Name, string Description, Dictionary<string, string> Exits, List<string> Items);