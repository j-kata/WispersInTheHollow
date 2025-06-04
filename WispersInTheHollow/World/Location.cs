namespace WispersInTheHollow.World;

internal class Location(string name, string description)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;

    private readonly List<Item> _items = [];
    public IReadOnlyList<Item> Items => _items;

    private readonly Dictionary<string, Location> _exits = [];
    public IReadOnlyDictionary<string, Location> Exits => _exits.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    public void AddItem(Item item) => _items.Add(item);
    public void RemoveItem(Item item) => _items.Remove(item);

    public void AddExit(string direction, Location exit) => _exits.Add(direction, exit);


    public string[] AvailableDirections()
    {
        return [.. _exits.Keys];
    }

    public IEnumerable<Item> GetHiddenItems()
    {
        return Items.Where(item => !item.IsDiscovered);
    }

    public IEnumerable<Item> GetVisibleItems()
    {
        return Items.Where(item => item.IsDiscovered);
    }
}
