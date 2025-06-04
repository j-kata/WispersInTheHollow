namespace WispersInTheHollow.World.Helpers;

internal interface IReadOnlyLocation
{
  public string Name { get; }
  public string Description { get; }
  public IReadOnlyList<Item> Items { get; }
  public IReadOnlyDictionary<string, IReadOnlyLocation> Exits { get; }
  public IReadOnlyLocation? GetExit(string direction);

  public string[] AvailableDirections();
  public IEnumerable<Item> AvailableItems();
  public Item? GetHiddenItem(string? itemName);
}
