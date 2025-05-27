namespace WispersInTheHollow.World;

internal class Location
{
  public string Name { get; set; }
  public string Description { get; set; }
  private readonly List<Item> Items = [];
  private readonly Dictionary<string, Location> Exits = [];

  public Location(string name, string description)
  {
    Name = name;
    Description = description;
  }

  public void AddItem(Item item)
  {
    Items.Add(item);
  }
  public void AddExit(string direction, Location exit)
  {
    Exits.Add(direction, exit);
  }

  public string[] AvailableDirections()
  {
    return [.. Exits.Keys];
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

  public Location? GetExit(string direction)
  {
    return Exits.TryGetValue(direction, out var location) ? location : null;
  }
}
