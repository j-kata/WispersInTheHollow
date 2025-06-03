using WispersInTheHollow.World.Helpers;

namespace WispersInTheHollow.World;

internal class Location : IReadOnlyLocation
{
  public string Name { get; private set; }
  public string Description { get; private set; }

  private readonly List<Item> _items = [];
  public IReadOnlyList<Item> Items => _items;

  private readonly Dictionary<string, Location> _exits = [];
  public IReadOnlyDictionary<string, IReadOnlyLocation> Exits => _exits.ToDictionary(kvp => kvp.Key, kvp => (IReadOnlyLocation)kvp.Value);

  public Location(string name, string description)
  {
    Name = name;
    Description = description;
  }

  internal void AddItem(Item item) => _items.Add(item);

  internal void AddExit(string direction, Location exit) => _exits.Add(direction, exit);


  public string[] AvailableDirections()
  {
    return [.. _exits.Keys];
  }

  public IEnumerable<Item> AvailableItems()
  {
    return Items;
  }

  public IEnumerable<Item> HiddenItems()
  {
    return Items.Where(item => !item.IsDiscovered);
  }

  public Item? Inspect(string itemName)
  {
    var item = HiddenItems().FirstOrDefault(item => item.Hint.Contains(itemName));
    if (item != null) item.IsDiscovered = true;

    return item;
  }

  public IReadOnlyLocation? GetExit(string direction)
  {
    return _exits.TryGetValue(direction, out var location) ? location : null;
  }
}
